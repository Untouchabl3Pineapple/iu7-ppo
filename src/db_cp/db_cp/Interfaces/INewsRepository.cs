using System.Collections.Generic;
using db_cp.Models;

namespace db_cp.Interfaces
{
    public interface INewsRepository
    {
        void Add(News news);

        IEnumerable<News> GetAll();
    }
}
