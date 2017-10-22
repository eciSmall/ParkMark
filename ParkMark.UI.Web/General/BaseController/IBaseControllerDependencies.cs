using AutoMapper;
using ParkMark.Infrastructure.Log;
using ParkMark.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkMark.UI.Web.General.BaseController
{
    public abstract class BaseController : Controller
    {
        //protected ISettingValueProvider SettingValue { get; }
        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }
        public BaseController(IBaseControllerDependencies baseDep)
        {
            //SettingValue = baseDep.SettingValue;
            Logger = baseDep.LoggerFactory.GetLogger(this);
            Mapper = baseDep.Mapper;
        }
    }
}
