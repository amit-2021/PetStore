using PetStore.Logger.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Logger.Logging.Implementations
{
    internal class DatabaseLogger : ILogger
    {
        private readonly string _databaseLogPath = "C:\\Acmeminds Projects\\project\\Test_Projects\\PetStore Helper File\\DataBase\\localLog.txt";

        public void Log(string message)
        {
            System.IO.File.AppendAllText(_databaseLogPath, $"{DateTime.Now}: {message}\n");
            Console.WriteLine($"Logged to DataBase at {_databaseLogPath}");
        }
    }
}
