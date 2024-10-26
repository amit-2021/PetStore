using PetStore.Logger.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Logger.Logging.Implementations
{
    internal class LocalLogger : ILogger
    {
        private readonly string _localLogPath = "C:\\Acmeminds Projects\\project\\Test_Projects\\PetStore Helper File\\Local\\localLog.txt";

        public void Log(string message)
        {
            System.IO.File.AppendAllText(_localLogPath, $"{DateTime.Now}: {message}\n");
            Console.WriteLine($"Logged to local at {_localLogPath}");
        }
    }
}
