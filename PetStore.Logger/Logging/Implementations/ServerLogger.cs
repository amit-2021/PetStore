using PetStore.Logger.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Logger.Logging.Implementations
{
    internal class ServerLogger : ILogger
    {
        private readonly string _serverLogPath = "C:\\Acmeminds Projects\\project\\Test_Projects\\PetStore Helper File\\Server\\localLog.txt";

        public void Log(string message)
        {
            System.IO.File.AppendAllText(_serverLogPath, $"{DateTime.Now}: {message}\n");
            Console.WriteLine($"Logged to server at {_serverLogPath}");
        }
    }
}
