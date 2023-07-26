using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemData.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using OnlineTicketBookingDataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Repository
{
   public class TicketBookingRepository : ITicketBookingRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TicketBookingRepository(DatabaseContext databaseContext)
        {
            _databaseContext=databaseContext;
        }

        public void Create(TicketBooking ticketBooking)
        {
            _databaseContext.TicketBookings.Add(ticketBooking);
        }

        public void Delete(int Id)
        {
            TicketBooking ticketBooking = _databaseContext.TicketBookings.Find(Id);
            _databaseContext.TicketBookings.Remove(ticketBooking);
        }

        public IEnumerable<TicketBooking> Get()
        {
            return _databaseContext.TicketBookings.ToList();
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void Update(TicketBooking ticketBooking)
        {
            _databaseContext.Entry(ticketBooking).State=EntityState.Modified;
        }
    }
}