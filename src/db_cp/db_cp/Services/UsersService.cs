using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Services
{
    public interface IUsersService
    {
        void Add(Users user);
        void Delete(Users user);
        void Update(Users user);

        IEnumerable<Users> GetAll();
        Users GetByLogin(string login);
    }

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        private bool IsExist(Users user)
        {
            return _usersRepository.GetAll().FirstOrDefault(elem =>
                    elem.Login == user.Login) != null;
        }

        private bool IsNotExist(string login)
        {
            return _usersRepository.GetByLogin(login) == null;
        }

        public void Add(Users user)
        {
            if (IsExist(user))
                throw new Exception("User with this login already exists");

            _usersRepository.Add(user);
        }

        public void Delete(Users user)
        {
            if (IsNotExist(user.Login))
                throw new Exception("User with this login does not exist");

            _usersRepository.Delete(user.Login);
        }

        public IEnumerable<Users> GetAll()
        {
            return _usersRepository.GetAll();
        }

        public Users GetByLogin(string login)
        {
            return _usersRepository.GetByLogin(login);
        }

        public void Update(Users user)
        {
            if (IsNotExist(user.Login))
                throw new Exception("User with this login does not exist");

            _usersRepository.Update(user);
        }
    }
}
