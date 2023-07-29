using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Model
{
   public class Customer
    {
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
        [Key]
         [JsonProperty("customerEmail")]
        public string CustomerEmail { get; set; }
         [JsonProperty("password")]
        public string Password { get; set; }
         [JsonProperty("role")]
        public string Role { get; set; }
    }
}
