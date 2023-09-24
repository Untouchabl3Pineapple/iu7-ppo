using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Services
{
    public interface INewsService
    {
        void Add(News news);

        IEnumerable<News> GetAll();
    }

    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        private bool IsExist(News news)
        {
            return _newsRepository.GetAll().FirstOrDefault(elem =>
                    elem.ID == news.ID) != null;
        }

        public void Add(News news)
        {
            if (IsExist(news))
                throw new Exception("An news with this ID already exists");

            _newsRepository.Add(news);
        }

        public IEnumerable<News> GetAll()
        {
            return _newsRepository.GetAll();
        }
    }
}
