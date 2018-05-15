using System.Collections.Generic;

namespace Library.Models.Models
{
    public class PublicationHouse : BaseEntity
    {
        public string Adress { get; set; }

        public virtual ICollection<PublicationHouseBooks> Books { get; set; }

        public PublicationHouse()
        {
            Books = new List<PublicationHouseBooks>();
        }

        public override string ToString()
        {
            string house = $"{Id}. Название издательства - {Name}, адрес - {Adress}";
            return house;
        }
    }
}
