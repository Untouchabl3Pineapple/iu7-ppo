using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Services
{
    public interface IEventsService
    {
        void Add(Events eevent);
        void Delete(Events eevent);
        void Update(Events eevent);

        IEnumerable<Events> GetAll();
        Events GetByID(int id);
    }

    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        private bool IsExist(Events eevent)
        {
            return _eventsRepository.GetAll().FirstOrDefault(elem =>
                    elem.ID == eevent.ID) != null;
        }

        private bool IsNotExist(int id)
        {
            return _eventsRepository.GetByID(id) == null;
        }

        public void Add(Events eevent)
        {
            if (IsExist(eevent))
                throw new Exception("An event with this ID already exists");

            _eventsRepository.Add(eevent);
        }

        public void Delete(Events eevent)
        {
            if (IsNotExist(eevent.ID))
                throw new Exception("Event with this ID does not exist");

            _eventsRepository.Delete(eevent.ID);
        }

        public IEnumerable<Events> GetAll()
        {
            return _eventsRepository.GetAll();
        }

        public void Update(Events eevent)
        {
            if (IsNotExist(eevent.ID))
                throw new Exception("Event with this ID does not exist");

            _eventsRepository.Update(eevent);
        }

        public Events GetByID(int id)
        {
            return _eventsRepository.GetByID(id);
        }
    }
}
