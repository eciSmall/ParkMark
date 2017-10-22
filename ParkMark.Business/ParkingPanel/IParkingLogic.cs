using ParkMark.Model.API.Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Business.ParkingPanel
{
    public interface IParkingLogic
    {
        AddParkingResponse AddParking(AddParkingRequest addParkingRequest);
    }
}
