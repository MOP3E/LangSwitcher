using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LangSwitcherLib
{
    internal class LanguageSwitch : ILoggable
    {
        /// <summary>
        /// Получить перечень языков в системе.
        /// </summary>
        /// <param name="nBuff">Максимальное количество дескрипторов, которые может содержать буфер.</param>
        /// <param name="lpList">Указатель на буфер, получающий массив входных идентификаторов языкового стандарта.</param>
        /// <returns>Если nBuff не 0 - количество выгруженных идентификаторов языка. Если nBuff = 0 - размер буфера, необходимый для выгрузки имён имеющихся в системе языков.</returns>
        [DllImport("user32.dll")]
        private static extern uint GetKeyboardLayoutList(int nBuff, [Out] IntPtr[] lpList);

        /// <summary>
        /// Получить текущйи активный язык.
        /// </summary>
        /// <param name="idThread">Идентификатор потока для запроса или 0 для текущего потока.</param>
        /// <returns>Возвращает идентификатор входного языкового стандарта для потока.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint idThread);

        /// <summary>
        /// Получить идентификатор текущего активного окна.
        /// </summary>
        /// <returns>Возвращает идентификатор текущего активного окна.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Получить идентификатор потока окна (и, при необходимости - идентификатор процесса).
        /// </summary>
        /// <param name="hWnd">Идентификатор окна.</param>
        /// <param name="processId">Идентификатор процесса окна.</param>
        /// <returns>Возвращает идентификатор потока окна.</returns>
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, [Out, Optional] int processId);

        /// <summary>
        /// Отправить сообщение окну.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// Загрузить язык.
        /// </summary>
        /// <param name="pwszKLID"></param>
        /// <param name="Flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int LoadKeyboardLayout(string pwszKLID, uint Flags);

        private const int WM_INPUTLANGCHANGEREQUEST = 0x50;
        private const int INPUTLANGCHANGE_SYSCHARSET = 0x1;

        /// <summary>
        /// Список 
        /// </summary>
        private IntPtr[] _systemLanguages;

        internal LanguageSwitch()
        {
            _systemLanguages = GetSystemLanguages();
        }

        private IntPtr[] GetSystemLanguages()
        {
            try
            {
                //определить число языков в системе
                uint size = GetKeyboardLayoutList(0, null);

                //задать размер буфера равный числу языков в системе
                IntPtr[] ids = new IntPtr[size];

                //загрузить дескрипторы языков в системе
                GetKeyboardLayoutList(ids.Length, ids);

                return ids;
            }
            catch (Exception e)
            {
                LogMessageEvent?.Invoke(Globals.LogFile, "LanguageSwitch.GetSystemLanguages:", e.Message);
                return null;
            }
        }

        /// <summary>
        /// Переключить язык текущего активного окна.
        /// </summary>
        public void ActiveWindowLanguagaeNext()
        {
            try
            {
                if(_systemLanguages == null || _systemLanguages.Length == 0)
                {
                    LogMessageEvent?.Invoke(Globals.LogFile, "LanguageSwitch.ActiveWindowLanguagaeNext:", "Список языков пуст.");

                    return;
                }

                //получить активное окно
                IntPtr foregroundWindow = GetForegroundWindow();

                //получить поток активного окна
                int processId = 0;
                uint foregroundWindowThread = GetWindowThreadProcessId(foregroundWindow, processId);

                //получить текущий язык потока активного окна
                IntPtr currentLanguage = GetKeyboardLayout(foregroundWindowThread);

                //найти язык активного окна в списке языцков
                int languageIndex = -1;
                for (int i = 0; i < _systemLanguages.Length; i++)
                {
                    if (currentLanguage == _systemLanguages[i])
                    {
                        languageIndex = i;
                    }
                }

                //проверить, найден ли язык
                if (languageIndex < 0) return;

                //перейти к следующему языку в списке
                languageIndex++;
                if (languageIndex >= _systemLanguages.Length) languageIndex = 0;

                //преобразовать номер языка в строку и загрузить его
                string lang = ((int)_systemLanguages[languageIndex] & 0xFFFF).ToString("X8");
                int newLayout = LoadKeyboardLayout(lang, 1);

                //отправить новый язык в активное окно
                PostMessage(foregroundWindow, WM_INPUTLANGCHANGEREQUEST, INPUTLANGCHANGE_SYSCHARSET, newLayout);
            }
            catch (Exception e)
            {
                LogMessageEvent?.Invoke(Globals.LogFile, "LanguageSwitch.ActiveWindowLanguagaeNext:", e.Message);
            }
        }

        public event LogMessage LogMessageEvent;
    }
}
