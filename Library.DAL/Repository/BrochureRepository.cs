using Library.DAL.Context;
using Library.Models.Models;

namespace Library.DAL.Repository
{
    public class BrochureRepository : Repository<Brochure>
    {
        public BrochureRepository(LibraryContext context) : base(context)
        { }
    }
}
