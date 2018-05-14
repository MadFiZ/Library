using System.Collections.Generic;

namespace Library.BLL.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
    }
}
