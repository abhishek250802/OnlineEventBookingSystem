using EventTicketBookingSystemData.Model; // Make sure to import the Customer model
using EventTicketBookingSystemMVC.Models; // Make sure to import the CustomerViewModel
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventTicketBookingSystemMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(); // Create a new HttpClient instance through DI
            _httpClient.BaseAddress = new Uri("https://localhost:7264"); // Set the base address of your API
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            List<CustomerViewModel> customersViewModel = new List<CustomerViewModel>();

            // Call the API to get customer data
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Customer");
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonResult);
                customersViewModel = customers.Select(c => MapToViewModel(c)).ToList();
            }

            return View(customersViewModel);
        }

        private CustomerViewModel MapToViewModel(Customer customer)
        {
            // Implement your mapping logic here to map Customer to CustomerViewModel
            return new CustomerViewModel
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                Password = customer.Password,
                // Map other properties as needed
            };
        }
    }
}








