using System.Web.Mvc;

namespace ParkMark.UI.Web.Areas.Dashboard
{
    public class DashboardAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "Dashboard_default",
               "Dashboard/{controller}/{action}/{id}",
                               new
                               {
                                   action = "Index",
                                   controller = "Home",
                                   id = UrlParameter.Optional,
                               },
                   namespaces: new[] { "ParkMark.UI.Web.Areas.Dashboard.Controllers" }

           );
        }
    }
}