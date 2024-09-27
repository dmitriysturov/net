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
}
