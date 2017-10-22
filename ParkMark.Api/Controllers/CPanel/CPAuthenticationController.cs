using ParkMark.Infrastructure.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkMark.Api.Controllers.CPanel
{
    public class CPAuthenticationController : BaseCPanelApiController
    {
        public Business.CPanel.IAdminLogic AdminLogic;
        public CPAuthenticationController(IBaseApiControllerDependencies baseDep, Business.CPanel.IAdminLogic adminLogic) : base(baseDep)
        {
            this.AdminLogic = adminLogic;
        }

        [Route("api/CPAuthentication")]
        [HttpPost]
        public Model.API.Admin.LoginResponse Login(Model.API.Admin.LoginRequest loginRequest)
        {
            return AdminLogic.AdminAuthenticate(loginRequest);
        }
    }
}