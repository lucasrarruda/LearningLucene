using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningLucene.Repository.Interfaces
{
    internal interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> Search(string query, int maxResults = 10);
    }
}
