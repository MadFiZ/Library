using Library.DAL.Context;
using Library.Models.Models;

namespace Library.DAL.Repository
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}
