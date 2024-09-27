using System;
using System.IO;
using Newtonsoft.Json;

namespace PcTechs.config
{
    public class Configuration
    {
        public required string LogLevel { get; set; }
        public required string LogDirectory { get; set; }
        public required string JsonDirectory { get; set; }
        public required string XmlDirectory { get; set; }

        public static Configuration LoadConfiguration(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Файл конфигурации {filePath} не найден.");
                }

                string configContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Configuration>(configContent);
            }
            catch (FileNotFoundException ex)
            {
                
                Console.WriteLine($"Ошибка чтения конфигурации: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Ошибка: {ex.Message}");
                throw new ConfigurationException("Ошибка при загрузке конфигурации.", ex);
            }
        }
    }

    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
