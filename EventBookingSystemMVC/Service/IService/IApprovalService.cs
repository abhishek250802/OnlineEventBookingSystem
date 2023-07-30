using EventTicketBookingSystemData.Model;

namespace EventTicketBookingSystemMVC.Service.IService
{
    public interface IApprovalService
    {
        Task<IEnumerable<Event>> GetUsersAsync();
        Task<bool> ApproveEvent(int id);
        Task<bool> RejectEvent(int id);
    }
}
