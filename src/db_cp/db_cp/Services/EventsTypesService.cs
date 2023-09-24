using System;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using db_cp.Models;

namespace db_cp.Services
{
    public interface IEventsTypesService
    {
        void Add(EventsTypes eventtype);
        void Delete(EventsTypes eventtype);
        void Update(EventsTypes eventtype);

        IEnumerable<EventsTypes> GetAll();
        EventsTypes GetByID(int id);
        EventsTypes GetByEventType(string eventtype);
    }

    public class EventsTypesService : IEventsTypesService
    {
        private readonly IEventsTypesRepository _eventsTypesRepository;

        public EventsTypesService(IEventsTypesRepository eventsTypesRepository)
        {
            _eventsTypesRepository = eventsTypesRepository;
        }

        private bool IsExist(EventsTypes eventtype)
        {
            return _eventsTypesRepository.GetAll().FirstOrDefault(elem =>
                    elem.ID == eventtype.ID) != null;
        }

        private bool IsNotExist(int id)
        {
            return _eventsTypesRepository.GetByID(id) == null;
        }

        public void Add(EventsTypes eventtype)
        {
            if (IsExist(eventtype))
                throw new Exception("An event type with this ID already exists");

            _eventsTypesRepository.Add(eventtype);
        }

        public void Delete(EventsTypes eventtype)
        {
            if (IsNotExist(eventtype.ID))
                throw new Exception("Event type with this ID does not exist");

            _eventsTypesRepository.Delete(eventtype.ID);
        }

        public IEnumerable<EventsTypes> GetAll()
        {
            return _eventsTypesRepository.GetAll();
        }

        public void Update(EventsTypes eventtype)
        {
            if (IsNotExist(eventtype.ID))
                throw new Exception("Event type with this ID does not exist");

            _eventsTypesRepository.Update(eventtype);
        }

        public EventsTypes GetByID(int id)
        {
            return _eventsTypesRepository.GetByID(id);
        }

        public EventsTypes GetByEventType(string eventtype)
        {
            return _eventsTypesRepository.GetByEventType(eventtype);
        }
    }
}
