using AutoMapper;
using ParkMark.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.UI.Web.General.BaseController
{
    public interface IBaseControllerDependencies
    {
        //Setting.ISettingValueProvider SettingValue { get; }
        ILoggerFactory LoggerFactory { get; }
        IMapper Mapper { get; }

    }
    public class BaseControllerDependencies : IBaseControllerDependencies
    {
        //public ISettingValueProvider SettingValue { get; }
        public ILoggerFactory LoggerFactory { get; }
        public IMapper Mapper { get; }

        public BaseControllerDependencies(ILoggerFactory loggerFactory, IMapper mapper)
        {
            //this.SettingValue = settingValueProvider;
            this.LoggerFactory = loggerFactory;
            this.Mapper = mapper;
        }
    }
}
