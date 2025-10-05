using System;
using System.IO;

namespace LangSwitcherLib
{
    internal class Log
    {
        private object _fileLock = new object();

        /// <summary>
        /// Папка для хранения текстовых логов.
        /// </summary>
        private string _logFolder;

        /// <summary>
        /// Папка для хранения текстовых логов.
        /// </summary>
        internal string LogFolder
        {
            get => _logFolder;
            private set
            {
                Directory.CreateDirectory(value);
                _logFolder = value;
            }
        }

        /// <summary>
        /// Регистрация логируемого объекта.
        /// </summary>
        /// <param name="o">Логируемый объект, у ктого есть интерфейс ILoggable.</param>
        internal void Register(ILoggable o)
        {
            //зарегистрировать обработчик сообщений для события записи в лог
            o.LogMessageEvent += MessageWriter;
        }

        /// <summary>
        /// Разрегистрация логируемого объекта.
        /// </summary>
        /// <param name="o">Логируемый объект, у ктого есть интерфейс ILoggable.</param>
        internal void Unregister(ILoggable o)
        {
            o.LogMessageEvent -= MessageWriter;
        }

        /// <summary>
        /// Запись сообщения в лог-файл.
        /// </summary>
        internal void MessageWriter(string logfile, string title, string mes)
        {
            lock (_fileLock)
            {
                File.AppendAllLines(Path.Combine(_logFolder, logfile) + ".log", new[] { "", DateTime.Now.ToString("G"), title, mes });
            }
        }

        internal Log(string logFolder)
        {
            LogFolder = logFolder;
        }
    }
}