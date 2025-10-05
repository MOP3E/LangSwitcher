using LangSwitcherLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LangSwitcher
{
    public partial class LangSwitcherSettingsDialog : Form
    {
        private bool _exit;

        /// <summary>
        /// Изменилось значение настройки автозапуска.
        /// </summary>
        private bool _autorunSwitched;

        public LangSwitcherSettingsDialog()
        {
            //запретить выход из программы
            _exit = false;
            InitializeComponent();
            //перевести интерфейс на нужный язык
            Localize();
            //установить список горячих клавиш в текущий режим переключечния клавиатуры
            ModeComboBox.SelectedIndex = (int)Globals.Settings.SwitchMode;
            //проверить, добавлена ли программа в автозагрузку
            AutorunCheckBox.Checked = AutorunTest();
        }

        /// <summary>
        /// Проверка, находится ли программа в автозагрузке.
        /// </summary>
        private bool AutorunTest()
        {
            object o = null;
            string exePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                //попытаться получить значение автозагрузки из реестра
                o = reg.GetValue(Name);
                //если значение не совпадает, значит в автозагрузке находится другая копия программы - удалить её из автозагрузки
                if (o != null && !string.Equals(exePath, o.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    reg.DeleteValue(Name);
                    o = null;
                }
                reg.Close();
            }
            catch
            {
                return false;
            }
            return o != null;
        }

        /// <summary>
        /// Настроить автозагрузку приложения.
        /// </summary>
        private bool SetAutorunValue(bool autorun)
        {
            string exePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(Name, exePath);
                else
                    reg.DeleteValue(Name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Перевод надписей на текущий системный язык.
        /// </summary>
        private void Localize()
        {
            CultureInfo russian = CultureInfo.CreateSpecificCulture("ru-ru");
            CultureInfo culture = CultureInfo.CurrentUICulture;

            if (culture.Name == russian.Name)
            {
                Text = "Переключение языка ввода";
                MainNotifyIcon.Text = "Переключение языка ввода";
                HintLabel.Text = "Выберите способ переключения языка ввода";
                ModeComboBox.Items.Clear();
                ModeComboBox.Items.AddRange(new[] { "Alt + Shift", "Ctrl + Shift", "Ё или знак ударения (`)" });
                CancelButton.Text = "Отмена";
                ApplyButton.Text = "Применить";
                SettingsMenuItem.Text = "Настройки";
                ExitMenuItem.Text = "Выход";
                AutorunCheckBox.Text = "Запускать вместе с Windows";
                return;
            }

            Text = "Input Language Switcher";
            MainNotifyIcon.Text = "Input Language Switcher";
            HintLabel.Text = "Choose hotkey to switch the input language";
            ModeComboBox.Items.Clear();
            ModeComboBox.Items.AddRange(new[] { "Alt + Shift", "Ctrl + Shift", "Grave accent (`)" });
            CancelButton.Text = "Cancel";
            ApplyButton.Text = "Apply";
            SettingsMenuItem.Text = "Settings";
            ExitMenuItem.Text = "Exit";
            AutorunCheckBox.Text = "Run with Windows";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MinimizeToTray();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Globals.Settings.SwitchMode = (SwitchMode)ModeComboBox.SelectedIndex;
            Globals.SaveSettings();
            if (_autorunSwitched) SetAutorunValue(AutorunCheckBox.Checked);
            MinimizeToTray();
        }

        /// <summary>
        /// Двойной щелчок по иконке в трее.
        /// </summary>
        private void MainNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ReturnFromTray();
        }

        /// <summary>
        /// Пункт контекстного меню для открывания настроек.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            ReturnFromTray();
        }

        /// <summary>
        /// Пункт контекстного меню для выхода из программы.
        /// </summary>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            _exit = true;
            Close();
        }

        /// <summary>
        /// Событие закрытия формы.
        /// </summary>
        private void LangSwitcherSettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //запретить закрытие с кнопки закрытия окна, вместо этого свернуть в трей
            if (!_exit)
            {
                e.Cancel = true;
                MinimizeToTray();
            }
        }

        /// <summary>
        /// Действия после загрузки формы.
        /// </summary>
        private void LangSwitcherSettingsDialog_Load(object sender, EventArgs e)
        {
            //свернуть окно в трей
            MinimizeToTray();
        }

        /// <summary>
        /// Переключение чекбокса автозапуска.
        /// </summary>
        private void AutorunCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _autorunSwitched = true;
        }

        /// <summary>
        /// Развернуть окно из трея.
        /// </summary>
        private void ReturnFromTray()
        {
            MainNotifyIcon.Visible = false;
            ShowInTaskbar = true;
            Visible = true;
        }

        /// <summary>
        /// Свернуть окно в трей.
        /// </summary>
        private void MinimizeToTray()
        {
            MainNotifyIcon.Visible = true;
            ShowInTaskbar = false;
            Visible = false;
        }
    }
}
