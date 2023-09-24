using db_cp.Interfaces;
using db_cp.Models;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Mocks
{
    public class ButtonsEventsMock : DataMock, IButtonsEventsRepository
    {
        public void Add(ButtonsEvents model)
        {
            _buttonsEvents.Add(model);
        }

        public void Delete(int id)
        {
            ButtonsEvents buttonEvent = _buttonsEvents[id - 1];
            _buttonsEvents.Remove(buttonEvent);
        }

        public void Update(ButtonsEvents model)
        {
            ButtonsEvents buttonEvent = _buttonsEvents[model.ID - 1];

            buttonEvent.ButtonColor = model.ButtonColor;
            buttonEvent.Number = model.Number;

            _buttonsEvents[buttonEvent.ID - 1] = buttonEvent;
        }

        public IEnumerable<ButtonsEvents> GetAll()
        {
            return _buttonsEvents;
        }

        public ButtonsEvents GetByID(int id)
        {
            return _buttonsEvents[id - 1];
        }
    }
}
