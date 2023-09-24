using System.Collections.Generic;
using db_cp.Models;

namespace db_cp.Interfaces
{
    public interface IButtonsPostsRepository
    {
        void Add(ButtonsPosts bpost);
        void Update(ButtonsPosts bpost);
        void Delete(int post);

        IEnumerable<ButtonsPosts> GetAll();
        ButtonsPosts GetByPost(int post);
    }
}
