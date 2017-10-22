using ParkMark.Model.Web;
using ParkMark.UI.Web.General;
using ParkMark.UI.Web.General.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkMark.UI.Web.Areas.Dashboard.Controllers
{
    public class BaseDashboardController : BaseController
    {
        protected APIService<DashboardAPIControllers> apiCaller = new APIService<DashboardAPIControllers>();

        public BaseDashboardController(IBaseControllerDependencies baseDep) : base(baseDep)
        {
        }
    }
}