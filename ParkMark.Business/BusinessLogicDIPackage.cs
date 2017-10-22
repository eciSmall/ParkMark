using ParkMark.Infrastructure.Business;
using ParkMark.Repository.CustomerPanel;
using ParkMark.Business.CustomerPanel;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkMark.Business.CPanel;
using ParkMark.Repository.CPanel;
using ParkMark.Repository.ParkingPanel;
using ParkMark.Business.ParkingPanel;

namespace ParkMark.Business
{
    public class BusinessLogicDIPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterRepository(container);


            container.Register<ILogicBaseDependencies, LogicBaseDependencies>(Lifestyle.Scoped);

            container.Register<ICustomerLogic, CustomerLogic>(Lifestyle.Scoped);
            container.Register<IAdminLogic, AdminLogic>(Lifestyle.Scoped);
            container.Register<IParkingLogic, ParkingLogic>(Lifestyle.Scoped);

        }

        private static void RegisterRepository(Container container)
        {
            container.Register<DbContext>(() => new ParkMark.Repository.Context(/*Model.API.ConfigValues.EntityFrameworkConntectionString*/), Lifestyle.Transient);

            container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Scoped);
            container.Register<IAdminRepository, AdminRepository>(Lifestyle.Scoped);
            container.Register<IParkingRepository, ParkingRepository>(Lifestyle.Scoped);
        }
    }
}
