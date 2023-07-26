using EventTicketBookingSystemData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Repository.IRepository
{
   public interface ITicketBookingRepository
    {
        public IEnumerable<TicketBooking> Get();
        public void Create(TicketBooking ticketBooking);
       
        public void Update(TicketBooking ticketBooking);
        public void Delete(int Id);
        public void Save();

    }
}