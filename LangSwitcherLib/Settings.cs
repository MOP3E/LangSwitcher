using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LangSwitcherLib
{
    /// <summary>
    /// Режим переключения языка.
    /// </summary>
    [Serializable]
    public enum SwitchMode
    {
        /// <summary>
        /// Одновременное нажатие клавиш Alt + Shift.
        /// </summary>
        AltShift,
        /// <summary>
        /// Одновременное нажатие Ctrl + Shift.
        /// </summary>
        CtrlShift,
        /// <summary>
        /// Нажатие кнопки Ё.
        /// </summary>
        Yo
    }

    [Serializable]
    public class Settings
    {
        /// <summary>
        /// Режим переключения языков ввода.
        /// </summary>
        public SwitchMode SwitchMode;

        public Settings()
        {
            SwitchMode = SwitchMode.AltShift;
        }

        /// <summary>
        /// Чтение настроек из файла.
        /// </summary>
        /// <param name="path">Путь к файлу настроек.</param>
        /// <param name="filename">Полное имя файла настроек.</param>
        public static Settings Load(string path, string filename)
        {
            Settings settings;

            //проверить, существует ли файл настроек
            if (File.Exists(filename))
            {
                try
                {
                    //попытаться десериализовать настройки из файла
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings), new[] { typeof(SwitchMode) });
                    using (Stream fstream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        settings = (Settings)serializer.Deserialize(fstream);
                    }
                }
                catch (Exception)
                {
                    //настройки десериализовать не получилось - удалить неправильный файл настроек и создать заново с настройками по умолчанию
                    settings = new Settings();
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings), new[] { typeof(SwitchMode) });
                    using (Stream fstream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        serializer.Serialize(fstream, settings);
                    }
                }
            }
            else
            {
                if (File.Exists(path))
                    File.Delete(path);
                //создать папку с настройками
                Directory.CreateDirectory(path);
                //создать файл с настройками
                settings = new Settings();
                XmlSerializer serializer = new XmlSerializer(typeof(Settings), new[] { typeof(SwitchMode) });
                using (Stream fstream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(fstream, settings);
                }
            }

            return settings;
        }

        /// <summary>
        /// Сохранение настроек в файл.
        /// </summary>
        /// <param name="settings">Настройки, которые нужно сохранить.</param>
        /// <param name="path">Путь к файлу настроек.</param>
        /// <param name="filename">Полное имя файла настроек.</param>
        public static void Save(Settings settings, string path, string filename)
        {
            //если файл настроек существует - удалить его
            if (File.Exists(filename)) File.Delete(filename);
            //создать папку с настройками
            Directory.CreateDirectory(path);
            //сериализовать настройки в файл
            XmlSerializer serializer = new XmlSerializer(typeof(Settings), new[] { typeof(SwitchMode) });
            using (Stream fstream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fstream, settings);
            }
        }
    }
}
