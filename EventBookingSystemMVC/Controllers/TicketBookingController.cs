using EventTicketBookingSystemMVC.Models;
using EventTicketBookingSystemMVC.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventTicketBookingSystemMVC.Controllers
{
    public class TicketBookingController : Controller
    {
        private readonly ITicketBookingService _ticketBookingService;
        private readonly IEventService _eventService;
        private readonly ICustomerService _customerService;
        private readonly UserManager<IdentityUser> _UserManagerr;

        public TicketBookingController(ITicketBookingService ticketBookingService, IEventService eventService, ICustomerService customerService, UserManager<IdentityUser> UserManager)
        {
            _ticketBookingService=ticketBookingService;
            _eventService=eventService;
            _customerService=customerService;
            _UserManagerr=UserManager;
        }
       
        public async Task<IActionResult> Index()
        {
            List<TicketBookingViewModel> list = new();

            var response = await _ticketBookingService.GetAllAsync<APIResponse>();

            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<TicketBookingViewModel>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public IActionResult CreateBooking(int eventid)
        {
            TempData["Eventid"]=eventid;

            return View();
        }
        public async Task<IActionResult> Create(TicketBookingViewModel ticketBookingViewModel)
        { ticketBookingViewModel.Id=0;
            ticketBookingViewModel.EventId=Convert.ToInt32( TempData["Eventid"]);
            ticketBookingViewModel.ApprovedStatus="Pending";
            ticketBookingViewModel.CustomerEmail = User.Identity.Name;
            await _ticketBookingService.CreateAsync<APIResponse>(ticketBookingViewModel);
            TempData["success"] = "Booking created successfully";
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Updatebyid(int id) {
            await _ticketBookingService.Updatebyid<APIResponse>(id);
            TempData["success"] = "Approved successfully";
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UpdatebyidReject(int id)
        {
            await _ticketBookingService.UpdatebyidReject<APIResponse>(id);
            TempData["success"] = "Rejected successfully";
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _ticketBookingService.DeleteAsync<APIResponse>(id);
            TempData["success"] = "Booking deleted successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            ViewData["Bookid"]=id;
           
            TicketBookingViewModel ticketBookingViewModel =new TicketBookingViewModel();
            CustomerViewModel customerViewModelS = new();
            EventViewModel eventViewModel=new EventViewModel();

            var detailsofticket = _ticketBookingService.Getbyid<APIResponse>(id);
            if (detailsofticket != null) { 

               ticketBookingViewModel = JsonConvert.DeserializeObject<TicketBookingViewModel>(Convert.ToString(detailsofticket.Result.Result)); 
            }
            var detailsofevent = _eventService.Getbyid<APIResponse>(ticketBookingViewModel.EventId);
            if (detailsofevent != null)
            {
               
              eventViewModel = JsonConvert.DeserializeObject<EventViewModel>(Convert.ToString(detailsofevent.Result.Result));
            }
                var cutsmoerdeatils = _customerService.Getbyid<APIResponse>(ticketBookingViewModel.CustomerEmail);
            
            if (cutsmoerdeatils != null)
            {
               customerViewModelS = JsonConvert.DeserializeObject<CustomerViewModel>(Convert.ToString(cutsmoerdeatils.Result.Result));
            }
                TicketbookingDetails ticketbookingDetails = new TicketbookingDetails()
                    
            {
                customerViewModel=customerViewModelS,
                EventViewModel=eventViewModel
            };

            ticketbookingDetails.customerViewModel.Password="";

            return View(ticketbookingDetails);

        }
        //public IActionResult aprovereject()
        //{

        //}

    }
}
