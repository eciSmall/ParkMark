using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Business.CustomerPanel
{
    public interface ICustomerLogic
    {
        Model.API.Customer.RegisterResponse CustomerRegister(Model.API.Customer.RegisterRequest registerRequest);
        Model.API.Customer.LoginResponse CustomerAuthenticate(Model.API.Customer.LoginRequest loginRequest);
        Model.API.Customer.PersonalInformationResponse GetCutomerInfo(Model.API.Customer.PersonalInformationRequest personalInformationRequest);
    }
}
