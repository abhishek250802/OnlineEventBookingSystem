using EventTicketBookingSystemData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Repository.IRepository
{
     public interface ICustomerRepository
    {
        public IEnumerable<Customer> Get();
       // public void Create(Customer customer);
        
        public void Update(Customer customer);
        public void Delete(string CustomerEmail);
        public void Save();

        bool IsUniqueCustomer(string customeremail);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<Customer> Register(Customer registerationRequest);
    }
}