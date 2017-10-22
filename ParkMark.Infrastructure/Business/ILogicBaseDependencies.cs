using AutoMapper;
using ParkMark.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.Business
{
    public interface ILogicBaseDependencies
    {
        ILoggerFactory LoggerFactory { get; }
        IMapper Mapper { get; }
    }

    public class LogicBaseDependencies : ILogicBaseDependencies
    {
        public ILoggerFactory LoggerFactory { get; }
        public IMapper Mapper { get; }

        public LogicBaseDependencies(ILoggerFactory loggerFactory, IMapper mapper)
        {
            this.LoggerFactory = loggerFactory;
            this.Mapper = mapper;
        }
    }
}
