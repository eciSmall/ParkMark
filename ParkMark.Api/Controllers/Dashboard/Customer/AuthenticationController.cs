using ParkMark.Infrastructure.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkMark.Api.Controllers.Dashboard.Customer
{
    public class AuthenticationController : BaseDashboardApiController
    {
        public Business.CustomerPanel.ICustomerLogic customerLogic;
        public AuthenticationController(IBaseApiControllerDependencies baseDep, ParkMark.Business.CustomerPanel.ICustomerLogic customerLogic) : base(baseDep)
        {
            this.customerLogic = customerLogic;
        }

        [Route("api/Authentication")]
        [HttpPost]
        public Model.API.Customer.LoginResponse Login(Model.API.Customer.LoginRequest loginRequest)
        {
            return customerLogic.CustomerAuthenticate(loginRequest);
        }

        [Route("api/Authentication")]
        [HttpPost]
        public Model.API.Customer.RegisterResponse Register(Model.API.Customer.RegisterRequest registerRequest)
        {
            return customerLogic.CustomerRegister(registerRequest);
        }

        [Route("api/Authentication")]
        [HttpPost]
        public Model.API.Customer.PersonalInformationResponse PersonalInformation(Model.API.Customer.PersonalInformationRequest personalInformationRequest)
        {
            return customerLogic.GetCutomerInfo(personalInformationRequest);
        }
    }
}