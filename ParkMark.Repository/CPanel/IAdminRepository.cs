using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Repository.CPanel
{
    public interface IAdminRepository
    {
        Model.ResponseStatus AdminAuthenticate(Model.API.Admin.LoginRequest loginRequest);
    }
}
