using System;
using db_cp.Models;
//using db_cp.Models.MongoDB;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Services
{
    public interface IButtonsEventsService
    {
        void Add(ButtonsEvents bevent);
        void Delete(ButtonsEvents bevent);
        void Update(ButtonsEvents bevent);

        IEnumerable<ButtonsEvents> GetAll();
        ButtonsEvents GetByID(int id);
    }

    public class ButtonsEventsService : IButtonsEventsService
    {
        private readonly IButtonsEventsRepository _buttonsEventsRepository;

        public ButtonsEventsService(IButtonsEventsRepository buttonsEventsRepository)
        {
            _buttonsEventsRepository = buttonsEventsRepository;
        }

        private bool IsExist(ButtonsEvents bevent)
        {
            return _buttonsEventsRepository.GetAll().FirstOrDefault(elem =>
                    elem.ID == bevent.ID) != null;
        }

        private bool IsNotExist(int id)
        {
            return _buttonsEventsRepository.GetByID(id) == null;
        }

        public void Add(ButtonsEvents bevent)
        {
            if (IsExist(bevent))
                throw new Exception("An event with this ID already exists");

            _buttonsEventsRepository.Add(bevent);
        }

        public void Delete(ButtonsEvents bevent)
        {
            if (IsNotExist(bevent.ID))
                throw new Exception("There is no such event");

            _buttonsEventsRepository.Delete(bevent.ID);
        }

        public IEnumerable<ButtonsEvents> GetAll()
        {
            return _buttonsEventsRepository.GetAll();
        }

        public void Update(ButtonsEvents bevent)
        {
            if (IsNotExist(bevent.ID))
                throw new Exception("There is no such event");

            _buttonsEventsRepository.Update(bevent);
        }

        public ButtonsEvents GetByID(int id)
        {
            return _buttonsEventsRepository.GetByID(id);
        }
    }
}
