using System;
using System.IO;
using System.Threading.Tasks;

namespace PcTechs.logs
{
    public class Logger<T>
    {
        public event Action<string>? LogEvent;

        // Асинхронное логирование
        public async Task LogAsync(T message)
        {
            string logMessage = $"{DateTime.Now}: {message.ToString()}";

            if (LogEvent != null)
            {
                await Task.Run(() => LogEvent(logMessage));
            }
        }

        // Синхронное логирование
        public void Log(T message)
        {
            string logMessage = $"{DateTime.Now}: {message.ToString()}";

            LogEvent?.Invoke(logMessage);
        }
    }
}
