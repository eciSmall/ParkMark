using ParkMark.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Repository.CustomerPanel
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        bool CheckCustomerExist(Model.API.Customer.RegisterRequest registerRequest);
        Model.ResponseStatus CustomerAuthenticate(Model.API.Customer.LoginRequest loginRequest);
    }
}
