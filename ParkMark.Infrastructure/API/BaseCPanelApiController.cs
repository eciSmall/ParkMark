using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.API
{
    public abstract class BaseCPanelApiController : BaseApiController
    {
        public BaseCPanelApiController(IBaseApiControllerDependencies baseDep) : base(baseDep)
        {
        }
    }
}
