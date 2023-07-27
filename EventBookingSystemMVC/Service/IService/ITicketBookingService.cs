using EventTicketBookingSystemMVC.Models;

namespace EventTicketBookingSystemMVC.Service.IService
{
    public interface ITicketBookingService
    {
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(TicketBookingViewModel ticketBookingViewModel);
        Task<T> UpdateAsync<T>(TicketBookingViewModel ticketBookingViewModel);
        Task<T> Getbyid<T>(int id);
        Task<T> DeleteAsync<T>(int id);
        Task<T> Updatebyid<T>(int id);
        Task<T> UpdatebyidReject<T>(int id);


    }
}