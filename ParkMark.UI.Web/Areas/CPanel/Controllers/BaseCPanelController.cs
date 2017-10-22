using ParkMark.Model.Web;
using ParkMark.UI.Web.General;
using ParkMark.UI.Web.General.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkMark.UI.Web.Areas.CPanel.Controllers
{
    public class BaseCPanelController : BaseController
    {
        protected APIService<CPanelAPIControllers> apiCaller = new APIService<CPanelAPIControllers>();

        public BaseCPanelController(IBaseControllerDependencies baseDep) : base(baseDep)
        {
        }
    }
}