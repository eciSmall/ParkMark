using ParkMark.Infrastructure.Business;
using ParkMark.Repository.CPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkMark.Model.API.Admin;

namespace ParkMark.Business.CPanel
{
    public class AdminLogic : LogicBase, IAdminLogic
    {
        IAdminRepository adminRepository;
        public AdminLogic(ILogicBaseDependencies baseDep, IAdminRepository iAdminRepository) : base(baseDep)
        {
            this.adminRepository = iAdminRepository;
        }
        public LoginResponse AdminAuthenticate(LoginRequest loginRequest)
        {
            var response = new Model.API.Admin.LoginResponse();
            try
            {
                response.Status = adminRepository.AdminAuthenticate(loginRequest);
                switch (response.Status)
                {
                    case Model.ResponseStatus.Success:
                        response.EndUserMessage = "Login Successful";
                        return response;
                    case Model.ResponseStatus.AccessDenied:
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
                return new Model.API.Admin.LoginResponse()
                {
                    Status = Model.ResponseStatus.InternalError,
                    EndUserMessage = "An InternalError Happend"
                };
            }
        }
    }
}
