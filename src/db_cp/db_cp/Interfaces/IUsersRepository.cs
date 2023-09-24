using System;
using db_cp.Models;
using System.Collections.Generic;

namespace db_cp.Interfaces
{
    public interface IUsersRepository
    {
        void Add(Users user);
        void Update(Users user);
        void Delete(string login);

        IEnumerable<Users> GetAll();
        Users GetByLogin(string login);
    }
}
