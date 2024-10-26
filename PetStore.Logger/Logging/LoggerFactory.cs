using PetStore.Logger.Enums;
using PetStore.Logger.Logging.Implementations;
using PetStore.Logger.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Logger.Logging
{
    public static class LoggerFactory
    {
        public static ILogger CreateLogger (LogType loggerType)
        {
            switch (loggerType)
            {
                case LogType.Local:
                    return new LocalLogger();
                    break;
                case LogType.Server:
                    return new ServerLogger();
                    break;
                case LogType.Database:
                    return new DatabaseLogger();
                    break;
                default:
                    return new LocalLogger();
            }
        }
    }
}
