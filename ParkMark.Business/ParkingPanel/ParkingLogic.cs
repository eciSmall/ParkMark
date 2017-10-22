using ParkMark.Infrastructure.Business;
using ParkMark.Model.API.Parking;
using ParkMark.Repository.ParkingPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Business.ParkingPanel
{
    public class ParkingLogic : LogicBase, IParkingLogic
    {
        IParkingRepository parkingRepository;
        public ParkingLogic(ILogicBaseDependencies baseDep, IParkingRepository iParkingRepository) : base(baseDep)
        {
            this.parkingRepository = iParkingRepository;
        }
        public AddParkingResponse AddParking(AddParkingRequest addParkingRequest)
        {
            try
            {
                if (parkingRepository.CheckParkingExist(addParkingRequest))
                {
                    return new AddParkingResponse
                    {
                        Status = Model.ResponseStatus.DuplicateObject,
                        EndUserMessage = "Duplicate Position"
                    };
                }
                else
                {
                    var parking = Mapper.Map<Repository.ParkingPlace>(addParkingRequest);
                    var response = new Model.API.Customer.RegisterResponse();
                    parkingRepository.Add(parking);
                    parkingRepository.Save();

                    return new AddParkingResponse
                    {
                        Status = Model.ResponseStatus.Success,
                        EndUserMessage = "Position Added Successful",
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new AddParkingResponse
                {
                    Status = Model.ResponseStatus.InternalError,
                    EndUserMessage = "An InternalError Happend"
                };
            }
        }
    }
}
