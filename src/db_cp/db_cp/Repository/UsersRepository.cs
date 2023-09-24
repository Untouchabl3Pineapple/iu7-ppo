using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace db_cp.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDBContext _appDBContext;

        public UsersRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void Add(Users model)
        {
            try
            {
                _appDBContext.Users.Add(model);
                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when adding User");
            }
        }

        public void Delete(string login)
        {
            try
            {
                Users user = _appDBContext.Users.Find(login);

                if (user != null)
                {
                    _appDBContext.Users.Remove(user);
                    _appDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when deleting User");
            }
        }

        public void Update(Users model)
        {
            try
            {
                var curModel = _appDBContext.Users.FirstOrDefault(elem => elem.Login == model.Login);
                _appDBContext.Entry(curModel).CurrentValues.SetValues(model);

                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when updating User");
            }
        }

        public IEnumerable<Users> GetAll()
        {
            return _appDBContext.Users.ToList();
        }

        public Users GetByLogin(string login)
        {
            return _appDBContext.Users.FirstOrDefault(elem => elem.Login == login);
        }
    }
}
