using System.Collections.Generic;
using db_cp.Models;

namespace db_cp.Interfaces
{
    public interface IButtonsEventsRepository
    {
        void Add(ButtonsEvents bevent);
        void Update(ButtonsEvents bevent);
        void Delete(int id);

        IEnumerable<ButtonsEvents> GetAll();
        ButtonsEvents GetByID(int id);
    }
}
