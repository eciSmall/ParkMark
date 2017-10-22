using ParkMark.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Repository.ParkingPanel
{
    public interface IParkingRepository : IRepository<ParkingPlace>
    {
        bool CheckParkingExist(Model.API.Parking.AddParkingRequest addParkingRequest);
    }
}
