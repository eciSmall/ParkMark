using ParkMark.Model.Web;
using ParkMark.UI.Web.General.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkMark.UI.Web.Controllers
{
    public abstract class BaseUIController : BaseController
    {
        public BaseUIController(IBaseControllerDependencies baseDep) : base(baseDep)
        {
        }

        protected General.APIService<APIControllers> apiService { get; set; } = new General.APIService<APIControllers>();
    }
}