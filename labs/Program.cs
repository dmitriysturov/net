/// <summary>
/// 
/// </summary>

using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PcTechs.models;
using PcTechs.UI;
using PcTechs.tests;
using PcTechs.logs;


namespace PcTechs
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding("Windows-1251");

            string formattedDate = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");


            Logger<string> logger = new Logger<string>();

            ConsoleLogger consoleLogger = new ConsoleLogger();

            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.Combine(rootDirectory, "..", "..", "..");
            string logFilePath = Path.Combine(projectDirectory, "logs", "logs", $"log_{formattedDate}.txt");

            FileLogger fileLogger = new FileLogger(logFilePath);


            logger.LogEvent += consoleLogger.PrintToConsole;
            logger.LogEvent += fileLogger.PrintToFile;

            logger.Log("Начало выполнения программы");

            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledExceptions;
            AppDomain.CurrentDomain.ProcessExit += HandleProcessExit;


             try
            {
                tests.ComponentTestData.AddTestComponents();
               
                Menu.DefaultMenu(logger);
            }
            catch (Exception ex)
            {
                logger.Log($"Программа завершена с ошибкой: {ex.Message}");
                throw; // Повторно выбрасываем исключение, чтобы оно не пропало
            }
            // Обработчик для необработанных исключений
            void HandleUnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
            {
                Exception exception = (Exception)e.ExceptionObject;
                logger.Log($"Необработанное исключение: {exception.Message}");
            }

            // Обработчик завершения программы
            void HandleProcessExit(object sender, EventArgs e)
            {
                logger.Log("Программа завершена.");
            }
        }        
    }
}
