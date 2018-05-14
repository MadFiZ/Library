using System.Collections.Generic;

namespace Library.Models.Models
{
    public class Book : BaseEntity
    {   
        public string Author { get; set; }

        public int YearOfPublishing { get; set; }

        /*public virtual ICollection<PublicationHouseBooks> PublicationHouses { get; set; }

        public Book()
        {
            PublicationHouses = new List<PublicationHouseBooks>();
        }*/

        public override string ToString()
        {
            string book = $"{Id}. Название книги - {Name}, автор - {Author}, год издательства - {YearOfPublishing}.";
            return book;
        }
    }
}