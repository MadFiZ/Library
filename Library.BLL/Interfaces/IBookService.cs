using Library.ViewModels.ViewModels;
using System.Collections.Generic;

namespace Library.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> GetItems();
        BookViewModel GetItem(long id);
        void InsertBook(BookViewModel addBook);
        void UpdateBook(BookViewModel editBook);
        void Delete(int id);
    }
}
