using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemMVC.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketBookingSystemMVC.Controllers
{
   //[Area("Admin")]

    [Authorize(Roles ="Admin")]
    public class ApprovalController : Controller
    {

        private readonly IApprovalService _approvalService;

        public ApprovalController(IApprovalService approvalService)
        {
            _approvalService = approvalService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _approvalService.GetUsersAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ApproveEvent(int id)
        {
            try
            {
                await _approvalService.ApproveEvent(id);
                TempData["Success"] = "Approved";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RejectEvent(int id)
        {
            try
            {
                await _approvalService.RejectEvent(id);
                TempData["Success"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Index");
            }
        } 
    }
}
