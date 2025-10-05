using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LangSwitcherLib
{
    internal class InterceptKeys
    {
        /// <summary>
        /// Подключить перехватчик событий Windows.
        /// </summary>
        /// <param name="idHook">Идентификатор типа перехватываемого события.</param>
        /// <param name="lpfn">Указатель на обработчик события.</param>
        /// <param name="hMod">Указатель на сборку, содержащую перехватчик.</param>
        /// <param name="dwThreadId">Идентификатор потока, с которым должна быть связан обработчик события.</param>
        /// <returns>Возвращает указатель на зарегистрированный перехватчик событий.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        /// <summary>
        /// Отключить перехватчик событий Windows.
        /// </summary>
        /// <param name="hhk">Указатель на перехватчик событий.</param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        /// Передать событие Windows для дальнейшей обработки.
        /// </summary>
        /// <param name="hhk">Неиспользуемый параметр.</param>
        /// <param name="nCode">Код события (nCode), переданный в текущий обработчик события.</param>
        /// <param name="wParam">wParam, переданный в текущий обработчик события.</param>
        /// <param name="lParam">lParam, переданный в текущий обработчик события.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Вернуть указатель на заданную сборку.
        /// </summary>
        /// <param name="lpModuleName">Имя сборки.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// Делегат для обработки события клавиатуры.
        /// </summary>
        /// <param name="nCode">Код, определяющий способ обработки события.</param>
        /// <param name="wParam">Идентификатор события клавиатуры.</param>
        /// <param name="lParam">Указатель на структуру KBDLLHOOKSTRUCT.</param>
        /// <returns>Возвращает то, что вернула функция CallNextHookEx.</returns>
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Перехыватывать события клавиатуры (нажатие и отпускание кнопок).
        /// </summary>
        private const int WH_KEYBOARD_LL = 13;

        /// <summary>
        /// Событие нажатия несистемной клавиши. Несистемная клавиша - это когда клавиша ALT не нажата.
        /// </summary>
        private const int WM_KEYDOWN = 0x0100;

        /// <summary>
        /// Событие отпускания несистемной клавиши. Несистемная клавиша - это когда клавиша ALT не нажата.
        /// </summary>
        private const int WM_KEYUP = 0x0101;

        /// <summary>
        /// Событие нажатия системной клавиши. Cистемная клавиша - клавиша F10, либо клавиша нажатая при удерживаемой нажатой клавише ALT.
        /// </summary>
        private const int WM_SYSKEYDOWN = 0x0104;

        /// <summary>
        /// Событие отпускания системной клавиши. Cистемная клавиша - клавиша F10, либо клавиша нажатая при удерживаемой нажатой клавише ALT.
        /// </summary>
        private const int WM_SYSKEYUP = 0x0105;

        /// <summary>
        /// Метод для обработки события клавиатуры.
        /// </summary>
        private static LowLevelKeyboardProc _proc = KeyboardHookCallback;

        /// <summary>
        /// Указатель на процедуру обработки события клавиатуры в формате Widnows.
        /// </summary>
        private static IntPtr _hookID = IntPtr.Zero;

        /// <summary>
        /// Перехватчик работает.
        /// </summary>
        private static bool _work = false;

        /// <summary>
        /// Таймер для контроля буфера нажатых клавиш.
        /// </summary>
        private static Timer _timer;

        /// <summary>
        /// Счётчик проверок буфера нажатых клавиш.
        /// </summary>
        private static int _pressedKeysTestCounter;

        /// <summary>
        /// Буфер нажатых клавиш.
        /// </summary>
        private static List<int> _pressedKeys = new List<int>();

        /// <summary>
        /// Комбинация клавиш готова к переключению.
        /// </summary>
        private static bool _ready;

        /// <summary>
        /// Запретить включение готовности до полной очистки списка нажатых кнопок.
        /// </summary>
        private static bool _readyBan;

        private static object _locker = new object();

        private static LanguageSwitch _switcher;

        /// <summary>
        /// Запуск перехватчика.
        /// </summary>
        public static void Start()
        {
            _switcher = new LanguageSwitch();

            _pressedKeysTestCounter = 0;
            _timer = new Timer(1000);
            _timer.Elapsed += PressedKeystest;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            _hookID = SetHook(_proc);
            _work = true;
        }

        private static void PressedKeystest(object sender, ElapsedEventArgs e)
        {
            lock (_locker)
            {
                //если буфер пуст - ничего не делать
                if(_pressedKeys.Count == 0)
                {
                    _pressedKeysTestCounter = 0;
                    return;
                }

                //буфер не поуст - считаем секунды пока не пройдёт 5 секунд
                _pressedKeysTestCounter++;
                if(_pressedKeysTestCounter < 6) return;

                //прошло 5 секунд, но буфер не очистился и нет реакции от клавиатуры (проверяются в KeyboardHookCallback) - очищаем буфер принудительно
                _pressedKeys.Clear();
                _pressedKeysTestCounter = 0;
            }
        }

        /// <summary>
        /// Остановка перехватчика.
        /// </summary>
        public static void Stop()
        {
            UnhookWindowsHookEx(_hookID);

            _timer.Enabled = false;
            _timer.Elapsed -= PressedKeystest;
            
            _work = false;
        }

        /// <summary>
        /// Подключение нашего обработчика к цепи обработки событий клавиатуры.
        /// </summary>
        /// <param name="proc">Ссылка на метод-обработчик.</param>
        /// <returns>Возвращает ссылку на процедуру-обработчик в формате Windows.</returns>
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                //ВАЖНО: Для программ Windows dwThreadId всегда равно 0. Не 0 только для приложений магазина майкрософт.
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        
        /// <summary>
        /// Обработка события клавиатуры.
        /// </summary>
        /// <param name="nCode">Код, определяющий способ обработки события.</param>
        /// <param name="wParam">Идентификатор события клавиатуры.</param>
        /// <param name="lParam">Указатель на структуру KBDLLHOOKSTRUCT.</param>
        /// <returns>Возвращает то, что вернула функция CallNextHookEx.</returns>
        private static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //обрабатывать только если nCode 0 или больше
            //ВАЖНО: если nCode меньше нуля - событие не обрабатывать и сразу передать его функции CallNextHookEx
            if (nCode >= 0)
            {
                int wp = (int)wParam;
                int vkCode = Marshal.ReadInt32(lParam);

                lock (_locker)
                {
                    //клавиатура работает - обнулить счётчик контроля буфера нажатий
                    _pressedKeysTestCounter = 0;

                    //при нажатии кнопки добавить её код в буфер нажатых кнопок, но только один раз
                    if (wp == WM_KEYDOWN || wp == WM_SYSKEYDOWN)
                        _pressedKeys.SortedAddOnce(vkCode);

                    //при отпускании кнопки удалить её код из буфера нажатых кнопок
                    if (wp == WM_KEYUP || wp == WM_SYSKEYUP)
                    {
                        _pressedKeys.Remove(vkCode);
                        if (_ready)
                        {
                            //переключить язык ввода
                            _switcher.ActiveWindowLanguagaeNext();
                        }
                    }

                    //проверка готовности к переключению языка ввода
                    if ((Globals.Settings.SwitchMode == SwitchMode.AltShift || Globals.Settings.SwitchMode == SwitchMode.CtrlShift) && _pressedKeys.Count > 2)
                    {
                        //запрет на переключение если нажаты лишние кнопки
                        _ready = false;
                        _readyBan = true;
                    }
                    else if (Globals.Settings.SwitchMode == SwitchMode.Yo && _pressedKeys.Count > 1)
                    {
                        //запрет на переключение если нажаты лишние кнопки
                        _ready = false;
                        _readyBan = true;
                    }
                    else if (Globals.Settings.SwitchMode == SwitchMode.AltShift && _pressedKeys.Count == 2)
                    {
                        //разрешение или запрет на переключение если нажато нужное количество кнопок
                        if (!_readyBan)
                        {
                            _ready = (_pressedKeys[0] == (int)Keys.LShiftKey || _pressedKeys[0] == (int)Keys.RShiftKey) &&
                                     (_pressedKeys[1] == (int)Keys.LMenu || _pressedKeys[1] == (int)Keys.RMenu);
                            _readyBan = !_ready;
                        }
                    }
                    else if (Globals.Settings.SwitchMode == SwitchMode.CtrlShift && _pressedKeys.Count == 2)
                    {
                        //разрешение или запрет на переключение если нажато нужное количество кнопок
                        if (!_readyBan)
                        {
                            _ready = (_pressedKeys[0] == (int)Keys.LShiftKey || _pressedKeys[0] == (int)Keys.RShiftKey) &&
                                     (_pressedKeys[1] == (int)Keys.LControlKey || _pressedKeys[1] == (int)Keys.RControlKey);
                            _readyBan = !_ready;
                        }
                    }
                    else if (Globals.Settings.SwitchMode == SwitchMode.Yo && _pressedKeys.Count == 1)
                    {
                        //разрешение или запрет на переключение если нажато нужное количество кнопок
                        if (!_readyBan)
                        {
                            _ready = _pressedKeys[0] == (int)Keys.Oemtilde;
                            _readyBan = !_ready;
                            return (IntPtr) 1;
                        }
                    }
                    else if ((Globals.Settings.SwitchMode == SwitchMode.AltShift || Globals.Settings.SwitchMode == SwitchMode.CtrlShift) && _pressedKeys.Count < 2)
                    {
                        //сброс триггеров если нажатых кнопок недостаточно для переключения
                        _ready = false;
                        _readyBan = false;
                    }
                    else if (Globals.Settings.SwitchMode == SwitchMode.Yo && _pressedKeys.Count < 1)
                    {
                        //сброс триггеров если нажатых кнопок недостаточно для переключения
                        _ready = false;
                        _readyBan = false;
                    }
                }
            }

            //передать событие дальше по команде
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
