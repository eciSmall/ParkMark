using ParkMark.Model.API.Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Business.MappingProfile.Parking
{
    public class ParkingMappingProfile : AutoMapper.Profile
    {
        public ParkingMappingProfile()
        {
            CreateMap<AddParkingRequest, Repository.ParkingPlace> ();
        }
    }
}
