using EventTicketBookingSystemMVC.Models;

namespace EventTicketBookingSystemMVC.Service.IService
{
   public interface ICustomerService
    {
       // Task<T> LoginAsync<T>(LoginRequestViewModel loginRequestViewModel);

        Task<T> RegisterAsync<T>(CustomerViewModel customerViewModel);
        Task<T> Getbyid<T>(string Email);

    }
}