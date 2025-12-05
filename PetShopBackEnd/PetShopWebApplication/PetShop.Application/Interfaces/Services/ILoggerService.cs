using PetShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Interfaces.Services
{
    public interface ILoggerService
    {
        void Log(LogLevel level, string message);
    }
}
