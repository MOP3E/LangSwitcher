using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LangSwitcherLib
{
    /// <summary>
    /// Глобальные константы, переменные и экземпляры.
    /// </summary>
    internal static class Globals
    {
        public const string AssemblyName = "LangSwitcherService";

        /// <summary>
        /// Объект для ведения логов.
        /// </summary>
        internal static Log Log { get; private set; }

        /// <summary>
        /// Имя файлал лога.
        /// </summary>
        internal const string LogFile = AssemblyName;

        /// <summary>
        /// Настройки программы.
        /// </summary>
        internal static Settings Settings { get; private set; }

        /// <summary>
        /// Папка с общими рабочими данными.
        /// </summary>
        internal const string ProgramDataFolder = AssemblyName;

        /// <summary>
        /// Папка с лог-файлами.
        /// </summary>
        internal static readonly string LogFolder = $@"{AssemblyName}\Logs";

        internal static void Init()
        {
            //инициализация системы логирования
            Log = new Log(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), LogFolder));

            //инициализация настроек программы
            LoadSettings();
        }

        /// <summary>
        /// Чтение настроек из файла настроек.
        /// </summary>
        /// <returns></returns>
        internal static void LoadSettings()
        {
            //сформировать путь к файлу настроек
            string path = FullPath(ProgramDataFolder);
            string filename = Path.Combine(path, $"{AssemblyName}.ini");

            Settings = Settings.Load(path, filename);
        }

        /// <summary>
        /// Сохранение настроек в файл настроек.
        /// </summary>
        internal static void SaveSettings()
        {
            //сформировать путь к файлу настроек
            string path = FullPath(ProgramDataFolder);
            string filename = Path.Combine(path, $"{AssemblyName}.ini");

            Settings.Save(Settings, path, filename);
        }

        /// <summary>
        /// Полный путь к указанной папке CecServer.
        /// </summary>
        internal static string FullPath(string folder)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), folder);
        }
    }
}
