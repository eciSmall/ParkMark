using ParkMark.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Logger
{
    public class LoggerFactory : ILoggerFactory
    {
        readonly ILogRequestContext requestContext;
        public LoggerFactory(ILogRequestContext requestContext)
        {
            this.requestContext = requestContext;
        }
        public ILogger GetLogger<T>()
        {
            return new NLogProxy<T>(requestContext);
        }

        public ILogger GetLogger(object typeObj)
        {
            return (ILogger)Activator.CreateInstance(typeof(Logger.NLogProxy<>).MakeGenericType(typeObj.GetType()), requestContext);
        }
    }
}
