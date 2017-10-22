using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Business.CPanel
{
    public interface IAdminLogic
    {
        Model.API.Admin.LoginResponse AdminAuthenticate(Model.API.Admin.LoginRequest loginRequest);
    }
}
