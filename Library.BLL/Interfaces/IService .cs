using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetItems();
        Task<IEnumerable<T>> GetItemsAsync();
        T GetItem(int id);
        Task<T> GetItemAsync(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
