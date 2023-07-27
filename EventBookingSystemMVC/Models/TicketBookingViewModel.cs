namespace EventTicketBookingSystemMVC.Models
{
    public class TicketBookingViewModel
    {
        
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public int NumberOfTickets { get; set; }
        public int EventId { get; set; }
        public string ApprovedStatus { get; set; }
    }
}