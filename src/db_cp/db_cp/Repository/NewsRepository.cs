using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace db_cp.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDBContext _appDBContext;

        public NewsRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void Add(News model)
        {
            try
            {
                _appDBContext.News.Add(model);
                _appDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception("Error when adding News");
            }
        }

        public IEnumerable<News> GetAll()
        {
            return _appDBContext.News.ToList();
        }
    }
}
