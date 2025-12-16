using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Services.Logging
{
    public class FileLoggerService : ILoggerService
    {
        public static readonly object _lock = new();
        private readonly string _filePath = "log.txt";

        public void Log(LogLevel level, string message)
        {
            string logEntry = $"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            lock (_lock) 
            {
                File.AppendAllText(_filePath, logEntry + Environment.NewLine);
            }
        }
    }
}
