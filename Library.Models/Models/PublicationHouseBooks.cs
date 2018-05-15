using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Models
{
    public class PublicationHouseBooks
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int PublicationHouseId { get; set; }
        public PublicationHouse PublicationHouse { get; set; }
    }
}
