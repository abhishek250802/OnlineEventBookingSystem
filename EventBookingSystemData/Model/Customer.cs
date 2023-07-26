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
        public string CustomerName { get; set; }
        [Key]
        public string CustomerEmail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
