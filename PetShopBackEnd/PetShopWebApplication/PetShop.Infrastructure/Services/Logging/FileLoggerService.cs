using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Infrastructure.Services.Logging
{
    public class FileLoggerService : ILoggerService
    {
        private readonly string _filePath = "log.txt";

        public void Log(LogLevel level, string message)
        {
            string logEntry = $"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_filePath, logEntry + Environment.NewLine);
        }
    }
}
