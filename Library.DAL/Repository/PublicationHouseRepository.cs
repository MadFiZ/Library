using Library.DAL.Context;
using Library.Models.Models;

namespace Library.DAL.Repository
{
    public class PublicationHouseRepository : Repository<PublicationHouse>
    {
        public PublicationHouseRepository(LibraryContext context) : base(context)
        { }
    }
}
