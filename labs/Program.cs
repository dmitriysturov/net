using System;
using System.IO;
using System.Text;
using PcTechs.models;
using PcTechs.UI;
using PcTechs.tests;
using PcTechs.logs;
using PcTechs.config;

namespace PcTechs
{
    class Program
    {
        private static Logger<string> logger = new Logger<string>();

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding("Windows-1251");

            string formattedDate = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            try
            {
                // Устанавливаем путь к config.json относительно корня проекта (labs/configuration)
                string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectDirectory = Path.Combine(rootDirectory, "..", "..", "..");
                string configFilePath = Path.Combine(projectDirectory, "configuration", "config.json");

                // Загружаем конфигурацию
                var config = Configuration.LoadConfiguration(configFilePath);

                logger = new Logger<string>();

                ConsoleLogger consoleLogger = new ConsoleLogger();

                // Путь для логов (labs/logs/logs)
                string logFilePath = Path.Combine(projectDirectory, "logs", "logs", $"log_{formattedDate}.log");

                FileLogger fileLogger = new FileLogger(logFilePath);

                // Подключаем логеры
                logger.LogEvent += consoleLogger.PrintToConsole;
                logger.LogEvent += fileLogger.PrintToFile;

                // Логируем начало работы
                logger.Log("Начало выполнения программы");

                // Подключаем обработчики для завершения программы и необработанных исключений
                AppDomain.CurrentDomain.UnhandledException += HandleUnhandledExceptions;
                AppDomain.CurrentDomain.ProcessExit += HandleProcessExit;

                // Добавляем тестовые компоненты
                tests.ComponentTestData.AddTestComponents();
                Menu.DefaultMenu(logger);
            }
            catch (ConfigurationException ex)
            {
                Console.WriteLine($"Ошибка конфигурации: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка: {ex.Message}");
            }
        }

        static void HandleUnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;
            logger.Log($"Необработанное исключение: {exception.Message}");
        }

        static void HandleProcessExit(object sender, EventArgs e)
        {
            logger.Log("Программа завершена.");
        }
    }
}
