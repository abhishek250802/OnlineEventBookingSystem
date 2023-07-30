using EventTicketBookingSystemData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventTicketBookingSystemData.Repository.IRepository
{
    public interface IEventRepository<T> where T : class
    {
        List <Event> Get(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Event GetbyId(int id);
         void Create(Event Entity);
         void Update(Event Entity);
         void Delete(Event Entity);
         void Save();
    }
}