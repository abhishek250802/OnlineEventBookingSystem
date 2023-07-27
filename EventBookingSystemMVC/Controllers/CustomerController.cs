using EventTicketBookingSystemMVC.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketBookingSystemMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService=customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}