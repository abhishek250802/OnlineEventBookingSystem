using System.ComponentModel.DataAnnotations;

namespace EventTicketBookingSystemMVC.Models
{
   public class CustomerViewModel
    {
         
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string CustomerName { get; set; }
        [Key]
        public string CustomerEmail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}