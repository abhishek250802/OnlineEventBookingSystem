using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemData.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingDataAccess.Data;

namespace EventTicketBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
  
    public class CustomerController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ICustomerRepository _customerRepository;
        protected ApiResponse _response;

        public CustomerController(DatabaseContext databaseContext, ICustomerRepository customerRepository)
        {
            _databaseContext=databaseContext;
            _customerRepository=customerRepository;
            this._response = new ApiResponse();
        }


        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var loginResponse = await _customerRepository.Login(model);
            if (loginResponse.Customer == null)
            {
                
                return BadRequest("Username or password is incorrect");
            }

            return Ok(loginResponse);
        }


        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] Customer model)
        {
            bool ifCustomerNameUnique = _customerRepository.IsUniqueCustomer(model.CustomerEmail);
            if (!ifCustomerNameUnique)
            { 
                return BadRequest("Username already exists");
            }



            var customer = await _customerRepository.Register(model);
            if (customer == null)
            {
              
                return BadRequest("Error while registering");
            }

            return Ok();
        }




        [HttpGet] 
       
        public IActionResult Get()
        {
            var result = _customerRepository.Get();
            return Ok(result);
        }

        [HttpGet("GetbyEmail/{CustomerEmail}")]
        public IActionResult Getbyid(string CustomerEmail)
        {
            var data = _databaseContext.Customers.Find(CustomerEmail);
            _response.Result=data;
            return Ok(_response);
        }
        //[HttpPost]
        //public IActionResult Create(Customer customer)
        //{

        //    _customerRepository.Create(customer);
        //    _customerRepository.Save();
        //    return Ok(_customerRepository.Get());
        //}
        [HttpPut]
     

        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);
            _customerRepository.Save();
            return Ok(_customerRepository.Get());
        }
        [HttpDelete]
    

        public IActionResult Delete(string CustomerEmail)
        {
            _customerRepository.Delete(CustomerEmail);
            _customerRepository.Save();
            return Ok(_customerRepository.Get());
        }


    }
}