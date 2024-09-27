using System;
using System.IO;

namespace PcTechs.logs
{
    public class Logger<T>
    {
        public event Action<string>? LogEvent;

        public void Log(T message)
        {
            string logMessage = $"{DateTime.Now}: {message.ToString()}";

            LogEvent?.Invoke(logMessage);
        }
    }


    public class FileLogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            // Проверяем и создаём директорию, если она не существует
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);  // Создаём директорию, если она не существует
            }

            _filePath = filePath;
        }

        // Метод для записи лога в файл
        public void PrintToFile(string message)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }

    

    
}
