using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MongoDB.Driver;

namespace db_cp.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly AppDBContext _appDBContext;

        public EventsRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void Add(Events model)
        {
            try
            {
                _appDBContext.Events.Add(model);
                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when adding Event");
            }
        }

        public void Delete(int id)
        {
            try
            {
                Events eevent = _appDBContext.Events.Find(id);

                if (eevent != null)
                {
                    _appDBContext.Events.Remove(eevent);
                    _appDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when deleting Event");
            }
        }

        public void Update(Events model)
        {
            try
            {
                var curModel = _appDBContext.Events.FirstOrDefault(elem => elem.ID == model.ID);
                _appDBContext.Entry(curModel).CurrentValues.SetValues(model);

                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when updating Event");
            }
        }

        public IEnumerable<Events> GetAll()
        {
            return _appDBContext.Events.ToList();
        }

        public Events GetByID(int id)
        {
            return _appDBContext.Events.Find(id);
        }
    }
}
