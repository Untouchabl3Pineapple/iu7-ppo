using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Mocks
{
    public class EventsTypesMock : DataMock, IEventsTypesRepository
    {
        public void Add(EventsTypes model)
        {
            _eventsTypes.Add(model);
        }

        public void Delete(int id)
        {
            EventsTypes eventsTypes = _eventsTypes[id - 1];
            _eventsTypes.Remove(eventsTypes);
        }

        public void Update(EventsTypes model)
        {
            EventsTypes eventsTypes = _eventsTypes[model.ID - 1];

            eventsTypes.EventType = model.EventType;

            _eventsTypes[eventsTypes.ID - 1] = eventsTypes;
        }

        public IEnumerable<EventsTypes> GetAll()
        {
            return _eventsTypes;
        }

        public EventsTypes GetByID(int id)
        {
            return _eventsTypes[id - 1];
        }

        public EventsTypes GetByEventType(string eventtype)
        {
            return _eventsTypes.FirstOrDefault(elem => elem.EventType == eventtype);
        }
    }
}
