using AutoMapper;
using ParkMark.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.Business
{
    public abstract class LogicBase
    {
        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }

        public LogicBase(ILogicBaseDependencies baseDepend)
        {
            Logger = baseDepend.LoggerFactory.GetLogger(this);
            Mapper = baseDepend.Mapper;
        }
    }
}
