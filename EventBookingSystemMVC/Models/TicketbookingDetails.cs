namespace EventTicketBookingSystemMVC.Models
{
    public class TicketbookingDetails
    {
        public CustomerViewModel customerViewModel { get; set; }
        public CustomerViewModel CustomerViewModel { get; internal set; }
        public EventViewModel EventViewModel { get; set; }
        public TicketBookingViewModel TicketBookingViewModel { get; internal set; }
    }
}