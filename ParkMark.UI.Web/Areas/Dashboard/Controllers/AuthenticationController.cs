using ParkMark.Model.API.Customer;
using ParkMark.UI.Web.General.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using ParkMark.Model.Web.Customer;

namespace ParkMark.UI.Web.Areas.Dashboard.Controllers
{
    public class AuthenticationController : BaseDashboardController
    {
        public AuthenticationController(IBaseControllerDependencies baseDep) : base(baseDep)
        {
        }

        // GET: Authentication  
        public ActionResult Login(CustomerLogin customerLogin)
        {
            return View(customerLogin);
        }
        [HttpPost]
        public ActionResult CheckAuthenticate(CustomerLogin customerLogin)
        {
            var result = apiCaller.Call<LoginRequest, LoginResponse>(Model.Web.DashboardAPIControllers.Authentication, "Login", HttpMethod.Post, new LoginRequest()
            {
                Email = customerLogin.Email,
                Password = customerLogin.Password

            });
            if (result.Status == Model.ResponseStatus.Success)
            {
                return RedirectToAction("Home", "Home", new { area = "" });
            }
            else
            {
                CustomerLogin customerLoginResponse = new CustomerLogin();
                customerLoginResponse.Status = result.Status;
                if (result.EndUserMessage != null)
                {
                    customerLoginResponse.EndUserMessage = result.EndUserMessage;
                }
                else
                {
                    customerLoginResponse.EndUserMessage = "Api Connection Problem!";
                }
                return View("Login", customerLoginResponse);
            }
        }
        public ActionResult CustomerLogout()
        {
            return View();
        }
        public ActionResult Register(CustomerRegister customerRegister)
        {
            return View(customerRegister);
        }
        [HttpPost]
        public ActionResult CustomerRegister(CustomerRegister customerRegister)
        {
            var req = Mapper.Map<RegisterRequest>(customerRegister);
            var result = apiCaller.Call<RegisterRequest, RegisterResponse>(Model.Web.DashboardAPIControllers.Authentication, "Register", HttpMethod.Post, new RegisterRequest()
            {
                Email = customerRegister.Email,
                Password = customerRegister.Password,
                RegisterDate = DateTime.Now,
            });
            if (result.Status == Model.ResponseStatus.Success)
            {
                return View("Login", new CustomerLogin()
                {
                    EndUserMessage = result.EndUserMessage,
                    Status = result.Status
                });
            }
            else
            {
                CustomerRegister customerRegisterResponse = new CustomerRegister();
                customerRegisterResponse.Status = result.Status;
                if (result.EndUserMessage != null)
                {
                    customerRegisterResponse.EndUserMessage = result.EndUserMessage;
                }
                else
                {
                    customerRegisterResponse.EndUserMessage = "Api Connection Problem!";
                }
                return View("Register", customerRegisterResponse);
            }
        }
    }
}