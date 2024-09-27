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
                string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectDirectory = Path.Combine(rootDirectory, "..", "..", "..");
                string configFilePath = Path.Combine(projectDirectory, "configuration", "config.json");

                var config = Configuration.LoadConfiguration(configFilePath);

                logger = new Logger<string>();

                ConsoleLogger consoleLogger = new ConsoleLogger();

                string logDirectory = config.LogDirectory ?? "logs/logs";  // Если путь не указан, используем дефолтный
                string logFilePath = Path.Combine(projectDirectory, logDirectory, $"log_{formattedDate}.log");

                FileLogger fileLogger = new FileLogger(logFilePath);

                logger.LogEvent += consoleLogger.PrintToConsole;
                logger.LogEvent += fileLogger.PrintToFile;

                logger.Log("Начало выполнения программы");

                AppDomain.CurrentDomain.UnhandledException += HandleUnhandledExceptions;
                AppDomain.CurrentDomain.ProcessExit += HandleProcessExit;

                tests.ComponentTestData.AddTestComponents();
                Menu.DefaultMenu(logger);
            }
            catch (ConfigurationException ex)
            {
                logger.Log($"Ошибка конфигурации: {ex.Message}");
                Console.WriteLine($"Ошибка конфигурации: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                logger.Log($"Файл не найден: {ex.Message}");
                Console.WriteLine($"Файл не найден: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.Log($"Общая ошибка: {ex.Message}");
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
