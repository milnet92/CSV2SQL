using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2SQL.Core
{
    public class Log
    {
        private static Log Instance = new Log();

        public delegate void LogMessageRaisedEventHandler(Object sender, LogEventArgs e);
        public static event LogMessageRaisedEventHandler MessageSent;

        public enum LogLevel
        {
            Information,
            Warning,
            Error
        }

        private Log() { }

        private void Add(string message, string details, LogLevel level, object origin)
        {
            Console.WriteLine($"[{level}] {message}");
            MessageSent?.Invoke(this, new LogEventArgs() { 
                Message = message, 
                Details = details, 
                LogLevel = level, 
                Origin = origin
            });
        }

        public static void AddMessage(string message, string details = "", LogLevel level = LogLevel.Information, object origin = null)
        {
            Instance.Add(message, details, level, origin);
        }
    }

}
