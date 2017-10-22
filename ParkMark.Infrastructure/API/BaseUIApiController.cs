using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.API
{
    public abstract class BaseUIApiController : BaseApiController
    {
        public BaseUIApiController(IBaseApiControllerDependencies baseDep) : base(baseDep)
        {
        }
    }
}
