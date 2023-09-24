using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using db_cp.Repository;

namespace db_cp.Mocks
{
    public class EventsMock : DataMock, IEventsRepository
    {
        public void Add(Events model)
        {
            _events.Add(model);
        }

        public void Delete(int id)
        {
            Events eevent = _events[id - 1];
            _events.Remove(eevent);
        }

        public void Update(Events model)
        {
            Events eevent = _events[model.ID - 1];

            eevent.ButtonEvent_ID = model.ButtonEvent_ID;
            eevent.EventType_ID = model.EventType_ID;
            eevent.EventDescription = model.EventDescription;
            eevent.DetectingTime = model.DetectingTime;
            eevent.FixingTime = model.FixingTime;
            eevent.TimeUpdate = model.TimeUpdate;
            eevent.User_Login = model.User_Login;

            _events[eevent.ID - 1] = eevent;
        }

        public IEnumerable<Events> GetAll()
        {
            return _events;
        }

        public Events GetByID(int id)
        {
            return _events[id - 1];
        }
    }
}
