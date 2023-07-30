using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemMVC.Service.IService;
using Newtonsoft.Json;
using System.Net;

namespace EventTicketBookingSystemMVC.Service
{
  public class ApprovalService:IApprovalService

    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7264";

        public ApprovalService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
            
        }
        public async Task<IEnumerable<Event>> GetUsersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Approval/GetAllApprovalsRejections");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Event>model = JsonConvert.DeserializeObject<IEnumerable<Event>>(content);
            return model;
        }

        public async Task<bool> ApproveEvent(int id)
        {
            var response = await _httpClient.GetAsync($"api/Approval/ApproveEvent?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Course not found.");
            }
            else
            {
                throw new Exception("Error while approving Course.");
            }
        }

        public async Task<bool> RejectEvent(int id)
        {
            var response = await _httpClient.GetAsync($"api/Approval/RejectEvent?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Course not found.");
            }
            else
            {
                throw new Exception("Error while rejecting Event.");
            }

        }

    }
}

