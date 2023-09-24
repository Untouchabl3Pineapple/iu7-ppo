using System.Collections.Generic;
using db_cp.Models;

namespace db_cp.Interfaces
{
    public interface IEventsRepository
    {
        void Add(Events eevent);
        void Update(Events eevent);
        void Delete(int id);

        IEnumerable<Events> GetAll();
        Events GetByID(int id);
    }
}
