using EventTicketBookingSystemMVC.Models;

namespace EventTicketBookingSystemMVC.Service.IService
{
    public interface IBaseService
    {
          APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}