using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.UI.Web.General.MappingProfile.Customer
{
    public class DashboardMappingProfile : AutoMapper.Profile
    {
        public DashboardMappingProfile()
        {
            CreateMap<Model.Web.Customer.CustomerRegister, Model.API.Customer.RegisterRequest>();
        }
    }
}
