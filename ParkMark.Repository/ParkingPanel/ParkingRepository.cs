using ParkMark.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Repository.ParkingPanel
{
    public class ParkingRepository : RepositoryBase<ParkingPlace>, IParkingRepository
    {
        private Context context;
        public ParkingRepository(IUnitOfWork uow) : base(uow)
        {
            context = new Context();
        }
        public bool CheckParkingExist(Model.API.Parking.AddParkingRequest addParkingRequest)
        {
            if (context.ParkingPlaces.Any(x => x.Latitude == addParkingRequest.Latitude) && context.ParkingPlaces.Any(x => x.Longitude == addParkingRequest.Longitude))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
