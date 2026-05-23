using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace ReqnRollProjectArchitecture.Support
{
    public static class LoggerHelper
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static void InitLogger()
        {
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            var logDir = Path.Combine(projectDir ?? AppDomain.CurrentDomain.BaseDirectory, "TestResults", "Logs");

            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            string logFileName = Path.Combine(logDir, $"ExecutionLog_{DateTime.Now:yyyyMMdd_HHmmss}.log");
            GlobalContext.Properties["LogFileName"] = logFileName;

            var logConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Credentials", "Log4Net.config");
            
            if (File.Exists(logConfigPath))
            {
                XmlConfigurator.Configure(new FileInfo(logConfigPath));
                _log.Info("Logger initialized successfully.");
            }
            else
            {
                Console.WriteLine($"[ERROR] Log4Net config file not found at: {logConfigPath}");
            }
        }

        public static void Info(string message) => _log.Info(message);
        public static void Debug(string message) => _log.Debug(message);
        public static void Error(string message) => _log.Error(message);
        public static void Error(string message, Exception ex) => _log.Error(message, ex);
        public static void Warning(string message) => _log.Warn(message);
    }
}
