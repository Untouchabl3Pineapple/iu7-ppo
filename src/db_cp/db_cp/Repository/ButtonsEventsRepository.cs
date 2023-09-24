using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace db_cp.Repository
{
    public class ButtonsEventsRepository : IButtonsEventsRepository
    {
        private readonly AppDBContext _appDBContext;

        public ButtonsEventsRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void Add(ButtonsEvents model)
        {
            try
            {
                _appDBContext.ButtonsEvents.Add(model);
                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when adding ButtonEvent");
            }
        }

        public void Delete(int id)
        {
            try
            {
                ButtonsEvents bevent = _appDBContext.ButtonsEvents.Find(id);

                if (bevent != null)
                {
                    _appDBContext.ButtonsEvents.Remove(bevent);
                    _appDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when deleting ButtonEvent");
            }
        }

        public void Update(ButtonsEvents model)
        {
            try
            {
                var curModel = _appDBContext.ButtonsEvents.FirstOrDefault(elem => elem.ID == model.ID);
                _appDBContext.Entry(curModel).CurrentValues.SetValues(model);
                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when updating ButtonEvent");
            }
        }

        public IEnumerable<ButtonsEvents> GetAll()
        {
            return _appDBContext.ButtonsEvents.ToList();
        }

        public ButtonsEvents GetByID(int id)
        {
            return _appDBContext.ButtonsEvents.Find(id);
        }
    }
}