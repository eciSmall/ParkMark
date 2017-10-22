using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Repository.CPanel
{
    public class AdminRepository : IAdminRepository
    {
        private Context context;
        public AdminRepository()
        {
            context = new Context();
        }
        public Model.ResponseStatus AdminAuthenticate(Model.API.Admin.LoginRequest loginRequest)
        {
            var admin = context.Admins.Where(x => x.UserName == loginRequest.UserName).SingleOrDefault();
            var response = new Model.API.Admin.LoginResponse();
            if (admin != null)
            {
                if (admin.Password == loginRequest.Password)
                {
                    return Model.ResponseStatus.Success;
                }
                else
                {
                    return Model.ResponseStatus.AccessDenied;
                }
            }
            else
            {
                return Model.ResponseStatus.AccessDenied;
            }
        }
    }
}
