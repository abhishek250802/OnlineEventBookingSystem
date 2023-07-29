//using EventTicketBookingSystemMVC.Models;

//namespace EventTicketBookingSystemMVC.Service.IService
//{
//   public interface ICustomerService
//    {
//       // Task<T> LoginAsync<T>(LoginRequestViewModel loginRequestViewModel);

//        Task<T> RegisterAsync<T>(CustomerViewModel customerViewModel);
//        Task<T> Getbyid<T>(string Email);
//        Task GetAllAsync<T>();
//    }
//}
using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemMVC.Models;
using System.Threading.Tasks;

namespace EventTicketBookingSystemMVC.Service.IService
{
    public interface ICustomerService
    {
        Task<T> Getbyid<T>(string CustomerEmail);
        Task<T> LoginAsync<T>(LoginRequestViewModel loginRequestViewModel);
        Task<T> RegisterAsync<T>(CustomerViewModel customerViewModel);
    }
}