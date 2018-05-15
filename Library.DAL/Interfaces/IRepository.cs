using Library.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        T Get(int id);
        Task<T> GetAsync(int id);
        void Add(T entity);
        Task<bool> AddAsync(T t);
        void Update(T entity, object key);
        Task<bool> UpdateAsync(T entity, object key);
        void Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        void Save();
        Task<bool> SaveAsync();
        void Dispose();
    }
}
