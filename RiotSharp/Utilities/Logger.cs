using System.Diagnostics;

namespace RiotSharp.Utilities
{
    public class Logger
    {
        public static readonly Lazy<Logger> Instance = new(() => new Logger());

        public event Action<string>? LogMessageReceived;

        private Logger() { }

        public void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        public void LogError(string message)
        {
            Log("ERROR", message);
        }

        public void LogError(string message, Exception exception)
        {
            Log("ERROR", $"{message} - Exception: {exception.Message}");
        }

        public void LogDebug(string message)
        {
            Log("DEBUG", message);
        }

        private void Log(string level, string message)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var logMessage = $"[{timestamp}] [{level}] {message}";
            
            Debug.WriteLine(logMessage);
            Console.WriteLine(logMessage);
            
            // Notify subscribers
            LogMessageReceived?.Invoke(logMessage);
        }
    }
}
