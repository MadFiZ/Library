using AutoMapper;
using Library.Models.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Library.Models.Models
{
    public class Book : BaseEntity
    {
        public string Author { get; set; }

        public int YearOfPublishing { get; set; }

        private ICollection<PublicationHouseBook> PublicationHouseBooks { get; set; } = new List<PublicationHouseBook>();

        [NotMapped]
        [IgnoreMap]
        public ICollection<PublicationHouse> PublicationHouses;

        public Book() => PublicationHouses = new JoinCollectionService<PublicationHouse, Book, PublicationHouseBook>(this, PublicationHouseBooks);

        public override string ToString()
        {
            string book = $"{Id}. Название книги - {Name}, автор - {Author}, год издательства - {YearOfPublishing}.";
            return book;
        }
    }
}