using AutoMapper;
using Library.Models.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Library.Models.Models
{
    public class PublicationHouse : BaseEntity
    {
        public string Adress { get; set; }

        private ICollection<PublicationHouseBook> PublicationHouseBooks { get; set; } = new List<PublicationHouseBook>();

        [NotMapped]
        [IgnoreMap]
        public ICollection<Book> Books;

        public PublicationHouse() => Books = new JoinCollectionService<Book, PublicationHouse, PublicationHouseBook>(this, PublicationHouseBooks);

        public override string ToString()
        {
            string house = $"{Id}. Название издательства - {Name}, адрес - {Adress}";
            return house;
        }
    }
}
