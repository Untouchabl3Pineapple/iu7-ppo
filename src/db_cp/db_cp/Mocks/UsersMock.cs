using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace db_cp.Mocks
{
    public class UsersMock : DataMock, IUsersRepository
    {
        public void Add(Users user)
        {
            _users.Add(user);
        }

        public void Delete(string login)
        {
            Users user = _users.FirstOrDefault(elem => elem.Login == login);
            _users.Remove(user);
        }

        public void Update(Users model)
        {
            Users user = _users.FirstOrDefault(elem => elem.Login == model.Login);

            user.Password = model.Password;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.MiddleName = model.MiddleName;

            _users[0] = user;
        }

        public IEnumerable<Users> GetAll()
        {
            return _users;
        }

        public Users GetByLogin(string login)
        {
            return _users.FirstOrDefault(elem => elem.Login == login);
        }
    }
}
