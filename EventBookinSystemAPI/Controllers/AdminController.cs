using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemData.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTicketBookingDataAccess.Data;

namespace EventTicketBookingSystemAPI.Controllers
{ 
   // [Route("api/[action]")]
    [Route("api/Approval/[action]")]
    
    [ApiController]
    
        

    public class AdminController : Controller
    {
     

    
        private readonly IEventRepository<Event> _eventRepository;
        private readonly DatabaseContext _dbContext;


        public AdminController(IEventRepository<Event> eventRepository, DatabaseContext databaseContext)
        {
            
            _eventRepository = eventRepository;
            _dbContext = databaseContext;

        }
        [HttpGet]
        public IActionResult GetAllApprovalsRejections()
        {
            try
            {

            
            IEnumerable<Event> model = _eventRepository.Get(e => e.IsRejected == false && e.IsApproved == false);
            if (model == null)
            {
                return NotFound();

            }
            else
            
            {
                return Ok(model);
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult ApproveEvent(int id)
        {
          if (id == 0)
            {
                return BadRequest();

            }

         
            Event model = _eventRepository.GetbyId(id);

            if (model == null)
            {
                return NotFound();

            }
            model.IsApproved = true;
            _dbContext.SaveChanges();
            return Ok(model);
}
[HttpGet]
public IActionResult RejectEvent(int id)
{
    if (id == 0)
    {
        return BadRequest();

    }

    Event Event = _eventRepository.GetbyId(id);
    if (Event == null)
    {
        return NotFound();

    }
    Event.IsRejected = true;
    _dbContext.SaveChanges();
    return Ok(Event);
}
    }
}
    
