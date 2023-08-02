using _02.DataAccessLayer.Context;
using _02.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _02.DataAccessLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private ApplicationContext context = new ApplicationContext();

        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }

        public List<T> All()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            context.SaveChanges();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
