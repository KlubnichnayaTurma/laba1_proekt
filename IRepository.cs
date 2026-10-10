using System.Collections.Generic;

namespace laba1.DAL
{
    public interface IRepository<T> where T : class
    {
        void Create(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T obj);
        void Delete(int id);
    }
}