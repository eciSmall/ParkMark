using ParkMark.UI.Web.General.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ParkMark.Model.API.Parking;

namespace ParkMark.UI.Web.Areas.CPanel.Controllers
{
    public class CPParkingController : BaseCPanelController
    {
        public CPParkingController(IBaseControllerDependencies baseDep) : base(baseDep)
        {
        }

        public ActionResult ParkingManager()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddParking(Model.Web.Parking.ParkingViewModel parkingViewModel)
        {
            var result = apiCaller.Call<AddParkingRequest, AddParkingResponse> (Model.Web.CPanelAPIControllers.CPParking, "AddParking", HttpMethod.Post, new AddParkingRequest()
            {
                Latitude = parkingViewModel.Latitude,
                Longitude = parkingViewModel.Longitude
            });
            parkingViewModel.Status = result.Status;
            parkingViewModel.EndUserMessage = result.EndUserMessage;
            return View("ParkingManager", parkingViewModel);
        }
    }
}