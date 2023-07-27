using EventTicketBookingSystemMVC.Models;
using EventTicketBookingSystemMVC.Service.IService;

namespace EventTicketBookingSystemMVC.Service
{
     public class CustomerService : BaseService, ICustomerService
    {
        private readonly IHttpClientFactory _clientFactory;

        private string TicketBookingUrl;
        public CustomerService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            TicketBookingUrl = configuration.GetValue<string>("ServiceUrls:BookTicket");

        }

        public Task<T> Getbyid<T>(string CustomerEmail)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = TicketBookingUrl + "/api/Customer/GetbyEmail/"+CustomerEmail,
                ApiType = "GET",

            });
        }

        public Task<T> LoginAsync<T>(LoginRequestViewModel loginRequestViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<T> RegisterAsync<T>(CustomerViewModel customerViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = TicketBookingUrl + "/api/Customer/register",
                ApiType = "Post",
                Data = customerViewModel

            });

        }
    }
}