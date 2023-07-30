using EventTicketBookingSystemMVC.Models;
using EventTicketBookingSystemMVC.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventTicketBookingSystemMVC.Controllers
{
   [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService=eventService;
        }
        public async Task<IActionResult> Index()
        {
            List<EventViewModel> list = new();

            var response = await _eventService.GetAllAsync<APIResponse>();
            
            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<EventViewModel>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public IActionResult AddEvent()
        {
            return View();
        }
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {
          await  _eventService.CreateAsync<APIResponse>(eventViewModel);
            TempData["success"] = "Event created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult editpage(int id)
        {
          
            var response= _eventService.Getbyid<APIResponse>(id);
            var data = Convert.ToString(response.Result.Result);
            if (response != null) {
                EventViewModel eventViewModel=JsonConvert.DeserializeObject<EventViewModel>(data);
                return View(eventViewModel);
            }

       
            return View();
        }
        public async Task<ActionResult> Edit(EventViewModel eventViewModel)
        {
            await _eventService.UpdateAsync<APIResponse>(eventViewModel);
            TempData["success"] = "Event updated successfully";
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int id)
        {
            await _eventService.DeleteAsync<APIResponse>(id);
            TempData["success"] = "Event deleted successfully";
            return RedirectToAction("Index");
        }
        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            List<EventViewModel> list = new();

            var response = await _eventService.GetAllAsync<APIResponse>();

            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<EventViewModel>>(Convert.ToString(response.Result));
            }

            return Json(new { data = list });


        }

        #endregion
    }
}
