using ParkMark.UI.Web.General.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkMark.Model.Web.Admin;
using System.Net.Http;
using ParkMark.Model.API.Admin;

namespace ParkMark.UI.Web.Areas.CPanel.Controllers
{
    public class CPAuthenticationController : BaseCPanelController
    {
        public CPAuthenticationController(IBaseControllerDependencies baseDep) : base(baseDep)
        {
        }
        public ActionResult Login(AdminLogin adminLogin)
        {
            return View(adminLogin);
        }
        [HttpPost]
        public ActionResult CheckAuthenticate(AdminLogin adminLogin)
        {
            var result = apiCaller.Call<LoginRequest, LoginResponse>(Model.Web.CPanelAPIControllers.CPAuthentication, "Login", HttpMethod.Post, new LoginRequest()
            {
                UserName = adminLogin.UserName,
                Password = adminLogin.Password
            });
            if (result.Status == Model.ResponseStatus.Success)
            {
                return RedirectToAction("Home", "Home", new { area = "" });
            }
            else
            {
                AdminLogin adminLoginResponse = new AdminLogin();
                adminLoginResponse.Status = result.Status;
                if (result.EndUserMessage != null)
                {
                    adminLoginResponse.EndUserMessage = result.EndUserMessage;
                }
                else
                {
                    adminLoginResponse.EndUserMessage = "Api Connection Problem!";
                }
                return View("Login", adminLoginResponse);
            }
        }
    }
}