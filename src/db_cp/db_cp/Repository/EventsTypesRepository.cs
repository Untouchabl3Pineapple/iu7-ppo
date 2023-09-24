using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace db_cp.Repository
{
    public class EventsTypesRepository : IEventsTypesRepository
    {
        private readonly AppDBContext _appDBContext;

        public EventsTypesRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void Add(EventsTypes model)
        {
            try
            {
                _appDBContext.EventsTypes.Add(model);
                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when adding EventType");
            }
        }

        public void Delete(int id)
        {
            try
            {
                EventsTypes etype = _appDBContext.EventsTypes.Find(id);

                if (etype != null)
                {
                    _appDBContext.EventsTypes.Remove(etype);
                    _appDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when deleting EventType");
            }
        }

        public IEnumerable<EventsTypes> GetAll()
        {
            return _appDBContext.EventsTypes.ToList();
        }

        public EventsTypes GetByID(int id)
        {
            return _appDBContext.EventsTypes.Find(id);
        }

        public EventsTypes GetByEventType(string eventtype)
        {
            return _appDBContext.EventsTypes.FirstOrDefault(elem => elem.EventType == eventtype);
        }

        public void Update(EventsTypes model)
        {
            try
            {
                var curModel = _appDBContext.EventsTypes.FirstOrDefault(elem => elem.ID == model.ID);
                _appDBContext.Entry(curModel).CurrentValues.SetValues(model);

                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when updating EventType");
            }
        }
    }
}
