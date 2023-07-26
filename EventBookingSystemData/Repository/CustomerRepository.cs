using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemData.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineTicketBookingDataAccess.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _databaseContext;
        private string secretKey;

        public CustomerRepository(DatabaseContext databaseContext, IConfiguration configuration)

        {
            _databaseContext=databaseContext;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
         
        }

        //public void Create(Customer customer)
        //{
        //    _databaseContext.Customers.Add(customer);
        //}

       

     

        public bool IsUniqueCustomer(string customeremail)
        {
            var customer = _databaseContext.Customers.FirstOrDefault(x => x.CustomerEmail == customeremail);
            if (customer == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var customer = _databaseContext.Customers.FirstOrDefault(u => u.CustomerEmail.ToLower() == loginRequest.Email.ToLower()
                && u.Password == loginRequest.Password);

            if (customer == null)
            {
                return new LoginResponse()
                {
                    Token = "",
                    Customer = null
                };

            }
            else
            {

                //if customer was found generate JWT Token

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, customer.CustomerEmail.ToString()),
                    new Claim(ClaimTypes.Role, customer.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };



                var token = tokenHandler.CreateToken(tokenDescriptor);
                LoginResponse loginResponse = new LoginResponse()
                {
                    Token = tokenHandler.WriteToken(token),
                    Customer= customer,

                };
                return loginResponse;
            }
        }


        public async Task<Customer> Register(Customer registerationRequest)
        {
            _databaseContext.Customers.Add(registerationRequest);
            await _databaseContext.SaveChangesAsync();
            registerationRequest.Password="";
            return registerationRequest;
            
        }




        public void Delete(string CustomerEmail)
        {
            Customer customer = _databaseContext.Customers.Find(CustomerEmail);
            _databaseContext.Customers.Remove(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return _databaseContext.Customers.ToList();
        }
        public void Update(Customer customer)
        {
            _databaseContext.Entry(customer).State=EntityState.Modified;
        }
        public void Save()
        {
            _databaseContext.SaveChanges();
        }
    }
}