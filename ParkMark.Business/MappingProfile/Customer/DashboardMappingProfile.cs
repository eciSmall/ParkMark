using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Business.MappingProfile.Customer
{
    public class DashboardMappingProfile : AutoMapper.Profile
    {
        public DashboardMappingProfile()
        {
            CreateMap<Model.API.Customer.RegisterRequest, Model.API.Customer.PersonalInformationResponse>();
            CreateMap<Model.API.Customer.RegisterRequest, Repository.Customer>();
        }
    }
}
