using System;

namespace PcTechs.logs
{
    public class ConsoleLogger
    {
        public void PrintToConsole(string message)
        {
            Console.WriteLine(message);
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