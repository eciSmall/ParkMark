using ParkMark.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Repository.CustomerPanel
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private Context context;
        public CustomerRepository(IUnitOfWork uow) : base(uow)
        {
            context = new Context();
        }

        //public Model.API.Customer.RegisterResponse CustomerRegister(Model.API.Customer.RegisterRequest registerRequest)
        //{
        //    context.Customers.Add(new Customer
        //    {
        //        Email = registerRequest.Email,
        //        Password = registerRequest.Password,
        //        RegisterDate = registerRequest.RegisterDate
        //    });
        //    context.SaveChanges();
        //    var response = new Model.API.Customer.RegisterResponse()
        //    {
        //        Email = registerRequest.Email,
        //        Status = Model.ResponseStatus.Success
        //    };
        //    return response;
        //}
        public bool CheckCustomerExist(Model.API.Customer.RegisterRequest registerRequest)
        {
            if (context.Customers.Any(x => x.Email == registerRequest.Email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Model.ResponseStatus CustomerAuthenticate(Model.API.Customer.LoginRequest loginRequest)
        {
            var customer = context.Customers.Where(x => x.Email == loginRequest.Email).SingleOrDefault();
            var response = new Model.API.Customer.LoginResponse();
            if (customer != null)
            {
                if (customer.Password == loginRequest.Password)
                {
                    return Model.ResponseStatus.Success;
                }
                else
                {
                    return Model.ResponseStatus.AccessDenied;
                }
            }
            else
            {
                return Model.ResponseStatus.AccessDenied;
            }
        }
    }
}
