using EventTicketBookingSystemData.Model;
using EventTicketBookingSystemData.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using OnlineTicketBookingDataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Repository
{
    public class EventRepository : IEventRepository<Event>
    {
        private readonly DatabaseContext _db;
        public EventRepository(DatabaseContext db)
        {
            _db = db;
        }
        public void Create(Event entity)
        {
            _db.Events.Add(entity);
            _db.SaveChanges();

        }

        public Event GetbyId(int Id)
        {

            return _db.Events.FirstOrDefault(u => u.EventId == Id);

        }
        

        public void Delete(Event entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }


        public void Update(Event entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }

        public List<Event> Get(Expression<Func<Event, bool>>? filter = null, string? includeProperties = null)
        {
            return _db.Events.ToList();
        }

           public void Save()
        {
             _db.SaveChanges();
        }
    }
}