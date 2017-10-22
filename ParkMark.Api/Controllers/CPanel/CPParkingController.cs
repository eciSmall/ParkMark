using ParkMark.Infrastructure.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkMark.Model.API.Parking;

namespace ParkMark.Api.Controllers.CPanel
{
    public class CPParkingController : BaseCPanelApiController
    {
        public Business.CPanel.IAdminLogic adminLogic;
        public Business.ParkingPanel.IParkingLogic parkingLogic;
        public CPParkingController(IBaseApiControllerDependencies baseDep, Business.CPanel.IAdminLogic adminLogic, Business.ParkingPanel.IParkingLogic parkingLogic) : base(baseDep)
        {
            this.adminLogic = adminLogic;
            this.parkingLogic = parkingLogic;
        }

        [HttpPost]
        public AddParkingResponse AddParking(AddParkingRequest addParkingRequest)
        {
            return parkingLogic.AddParking(addParkingRequest);
        }
    }
}