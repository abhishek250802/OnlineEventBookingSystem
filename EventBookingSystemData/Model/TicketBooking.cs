using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Model
{
    public class TicketBooking
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string CustomerEmail { get; set; }
        public int NumberOfTickets { get; set;}
        public int EventId { get; set; }
        public string ApprovedStatus { get; set; }
    }
}
