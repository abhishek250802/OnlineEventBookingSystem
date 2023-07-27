using System.ComponentModel.DataAnnotations;

namespace EventTicketBookingSystemMVC.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        [StringLength(20, ErrorMessage = "Event Name cannot exceed 20 characters.")]
        public string EventName { get; set; }
        [StringLength(500, ErrorMessage = "Event Description cannot exceed 500 characters.")]
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Available Seats must be a non-negative number.")]
        public int AvailableSeats { get; set; }
    
}
}