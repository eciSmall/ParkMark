using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Model.API.Parking
{
    public class AddParkingRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
