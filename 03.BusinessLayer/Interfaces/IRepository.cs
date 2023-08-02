using System.Collections.Generic;

namespace _02.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        List<T> All();
        T GetById(int id);

    }
}
