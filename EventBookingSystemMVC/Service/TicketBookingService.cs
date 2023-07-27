using EventTicketBookingSystemMVC.Models;
using EventTicketBookingSystemMVC.Service.IService;

namespace EventTicketBookingSystemMVC.Service
{
    public class TicketBookingService : BaseService, ITicketBookingService
    {
        private readonly IHttpClientFactory _clientFactory;

        private string TicketBookingUrl;
        public TicketBookingService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            TicketBookingUrl = configuration.GetValue<string>("ServiceUrls:BookTicket");

        }

        public Task<T> CreateAsync<T>(TicketBookingViewModel ticketBookingViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Post",
                Data=ticketBookingViewModel,
                Url =TicketBookingUrl + "/api/TicketBooking"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Delete",
          
                Url = TicketBookingUrl + "/api/TicketBooking/"+id

            });

        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",
                
                Url = TicketBookingUrl + "/api/TicketBooking"

            });
        }

        public Task<T> Getbyid<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",
              
                Url = TicketBookingUrl + "/api/TicketBooking/"+id

            });
        }

        public Task<T> UpdateAsync<T>(TicketBookingViewModel ticketBookingViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                Data=ticketBookingViewModel,
                Url = TicketBookingUrl + "/api/TicketBooking"

            });
        }



        public Task<T> Updatebyid<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType= "Put",
                Url = TicketBookingUrl + "/api/TicketBooking/Approve/"+id
            }
                );
        }

            public Task<T> UpdatebyidReject<T>(int id)
            {
                return SendAsync<T>(new APIRequest()
                {
                    ApiType= "Put",
                    Url = TicketBookingUrl + "/api/TicketBooking/Reject/"+id
                }
                    );


            }
    }
}