using Library.Models.Models;
using System.Collections.Generic;

namespace Library.DAL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
