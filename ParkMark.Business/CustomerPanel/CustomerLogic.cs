using ParkMark.Infrastructure.Business;
using ParkMark.Repository.CustomerPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Business.CustomerPanel
{
    public class CustomerLogic : LogicBase, ICustomerLogic
    {
        ICustomerRepository customerRepository;
        public CustomerLogic(ILogicBaseDependencies baseDep, ICustomerRepository iCustomerRepository) : base(baseDep)
        {
            this.customerRepository = iCustomerRepository;
        }
        public Model.API.Customer.RegisterResponse CustomerRegister(Model.API.Customer.RegisterRequest registerRequest)
        {
            try
            {
                if (customerRepository.CheckCustomerExist(registerRequest))
                {
                    return new ParkMark.Model.API.Customer.RegisterResponse()
                    {
                        Status = ParkMark.Model.ResponseStatus.DuplicateObject,
                        EndUserMessage = "Duplicate Email"
                    };
                }
                else
                {
                    var customer = Mapper.Map<Repository.Customer>(registerRequest);
                    var response = new Model.API.Customer.RegisterResponse();
                    customer = customerRepository.Add(customer);
                    customerRepository.Save();
                    response.Email = customer.Email;
                    response.Status = Model.ResponseStatus.Success;
                    response.EndUserMessage = "Register Successful";
                    return response;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new Model.API.Customer.RegisterResponse()
                {
                    Status = Model.ResponseStatus.InternalError,
                    EndUserMessage = "An InternalError Happend"
                };
            }
        }
        public Model.API.Customer.LoginResponse CustomerAuthenticate(Model.API.Customer.LoginRequest loginRequest)
        {
            var response = new ParkMark.Model.API.Customer.LoginResponse();
            try
            {
                response.Status = customerRepository.CustomerAuthenticate(loginRequest);
                switch (response.Status)
                {
                    case ParkMark.Model.ResponseStatus.Success:
                        response.EndUserMessage = "Login Successful";
                        return response;
                    case ParkMark.Model.ResponseStatus.AccessDenied:
                        response.EndUserMessage = "Email Or Password Is Incorrect";
                        return response;
                    default:
                        response.EndUserMessage = "Unknown ERROR";
                        return response;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new Model.API.Customer.LoginResponse()
                {
                    Status = Model.ResponseStatus.InternalError,
                    EndUserMessage = "An InternalError Happend"
                };
            }
        }
        public Model.API.Customer.PersonalInformationResponse GetCutomerInfo(Model.API.Customer.PersonalInformationRequest personalInformationRequest)
        {
            var customer = customerRepository.Find(personalInformationRequest.Email);
            var result = Mapper.Map<Model.API.Customer.PersonalInformationResponse>(customer);
            return result;
        }
    }
}
