using System;
using db_cp.Models;
using System.Collections.Generic;

namespace db_cp.Interfaces
{
    public interface IEventsTypesRepository
    {
        void Add(EventsTypes eventtype);
        void Update(EventsTypes eventtype);
        void Delete(int id);

        IEnumerable<EventsTypes> GetAll();
        EventsTypes GetByID(int id);
        EventsTypes GetByEventType(string eventtype);
    }
}
