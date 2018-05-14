using Library.DAL.Context;
using Library.Models.Models;

namespace Library.DAL.Repository
{
    public class MagazineRepository : Repository<Magazine>
    {
        public MagazineRepository(LibraryContext context) : base(context)
        { }
    }
}
