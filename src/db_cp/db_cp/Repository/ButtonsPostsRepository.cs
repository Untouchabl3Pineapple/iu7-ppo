using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace db_cp.Repository
{
    public class ButtonsPostsRepository : IButtonsPostsRepository
    {
        private readonly AppDBContext _appDBContext;

        public ButtonsPostsRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void Add(ButtonsPosts model)
        {
            try
            {
                _appDBContext.ButtonsPosts.Add(model);
                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when adding ButtonPost");
            }
        }

        public void Delete(int post)
        {
            try
            {
                ButtonsPosts bpost = _appDBContext.ButtonsPosts.Find(post);

                if (bpost != null)
                {
                    _appDBContext.ButtonsPosts.Remove(bpost);
                    _appDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when deleting ButtonPost");
            }
        }

        public void Update(ButtonsPosts model)
        {
            try
            {
                var curModel = _appDBContext.ButtonsPosts.FirstOrDefault(elem => elem.Post == model.Post);
                _appDBContext.Entry(curModel).CurrentValues.SetValues(model);

                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when updating ButtonPost");
            }
        }

        public IEnumerable<ButtonsPosts> GetAll()
        {
            return _appDBContext.ButtonsPosts.ToList();
        }

        public ButtonsPosts GetByPost(int post)
        {
            return _appDBContext.ButtonsPosts.Find(post);
        }
    }
}
