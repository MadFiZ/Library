using Library.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Models
{
    public class PublicationHouseBook : IJoinEntity<Book>, IJoinEntity<PublicationHouse>
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        Book IJoinEntity<Book>.Navigation
        {
            get => Book;
            set => Book = value;
        }

        public int PublicationHouseId { get; set; }
        public PublicationHouse PublicationHouse { get; set; }
        PublicationHouse IJoinEntity<PublicationHouse>.Navigation
        {
            get => PublicationHouse;
            set => PublicationHouse = value;
        }
    }
}
