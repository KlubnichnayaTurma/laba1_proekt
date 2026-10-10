using System.Collections.Generic;
using laba1;

namespace DataAccessLayer
{ 
    public interface IRepository<T> where T : IDomainObject
    {
        void Add(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T obj);
        void Delete(int id);
    }
}