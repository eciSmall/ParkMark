using AutoMapper;
using ParkMark.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.API
{
    public interface IBaseApiControllerDependencies
    {
        //Setting.ISettingValueProvider SettingValue { get; }
        ILoggerFactory LoggerFactory { get; }
        IMapper Mapper { get; }
    }
    public class BaseApiControllerDependencies : IBaseApiControllerDependencies
    {
        //public ISettingValueProvider SettingValue { get; }
        public ILoggerFactory LoggerFactory { get; }
        public IMapper Mapper { get; }
        public BaseApiControllerDependencies(ILoggerFactory loggerFactory, IMapper mapper)
        {
            //this.SettingValue = settingValueProvider;
            this.LoggerFactory = loggerFactory;
            this.Mapper = mapper;
        }
    }
}
