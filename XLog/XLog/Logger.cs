
#region imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace XLog {
   public class Logger {
        public string logFilePath { get; set; } = string.Empty;
        public string logTimeFormat { get; set; } = string.Empty;
        public string logTextFormat { get; set; } = string.Empty;
        public Dictionary<LogType, ConsoleColor> colors= new Dictionary<LogType, ConsoleColor>() {
            {LogType.DEBUG, ConsoleColor.White},
            {LogType.INFO, ConsoleColor.Blue},
            {LogType.WARNING, ConsoleColor.DarkYellow},
            {LogType.ERROR, ConsoleColor.Red},
            {LogType.FORCE, ConsoleColor.DarkGray}
        };
        private static string currentTime = string.Empty;
        private static void FileWriter(string logTextFormat, string logFilePath, LogType logType, string logText) {
            if (logFilePath == string.Empty) {
                Directory.CreateDirectory("logs");
                logFilePath = "logs/log";
            }

            var logDirectory = Path.GetDirectoryName(logFilePath);
            if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory)) {
                Directory.CreateDirectory(logDirectory);
            }

            if (logFilePath != string.Empty) {
                using (StreamWriter streamWriter = new StreamWriter($"{logFilePath}.xlog", true)) {
                    streamWriter.WriteLine(logTextFormat, currentTime, logType.ToString(), logText);
                }
            }
            else return;
        }
        public void Log(LogType logType, string logText) {
            if (logTimeFormat == string.Empty) {
                logTimeFormat = "yyyy-MM-dd HH:mm:ss";
            }
            if(logTextFormat == string.Empty){
                logTextFormat = "{0} - {1} - {2}";
            }
            currentTime = DateTime.Now.ToString(logTimeFormat);

            FileWriter(logTextFormat, logFilePath, logType, logText);
            
            ConsoleColor color = colors[logType];
            Console.ForegroundColor = color;
            Console.WriteLine(logTextFormat, currentTime, logType.ToString(), logText);
            Console.ResetColor();
        }
    }
}
