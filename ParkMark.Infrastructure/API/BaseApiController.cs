using AutoMapper;
using ParkMark.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ParkMark.Infrastructure.API
{
    public abstract class BaseApiController : ApiController
    {
        //protected ISettingValueProvider SettingValue { get; }
        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }
        public BaseApiController(IBaseApiControllerDependencies baseDep)
        {
            //SettingValue = baseDep.SettingValue;
            Logger = baseDep.LoggerFactory.GetLogger(this);
            Mapper = baseDep.Mapper;
        }
    }
}
