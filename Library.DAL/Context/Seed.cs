using Library.Enums.Enums;
using Library.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Library.DAL.Context
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                Book book = new Book
                {
                    Name = "Война и мир",
                    Author = "Л. Толстой",
                    YearOfPublishing = 1998
                };
                PublicationHouse house = new PublicationHouse
                {
                    Name = "qwerty",
                    Adress = "Tales-Street"
                };
                /* var housebook = new PublicationHouseBooks
                 {
                     BookId = book.Id,
                     Book = book,
                     PublicationHouseId = house.Id,
                     PublicationHouse = house
                 };*/
                /*house.Books.Add(housebook);
                book.PublicationHouses.Add(housebook);*/
                if (!context.Books.Any())
                {
                    context.Books.Add(new Book
                    {
                        Name = "Отцы и дети",
                        Author = "И. Тургенев",
                        YearOfPublishing = 2016,
                        /*PublicationHouses = new List<PublicationHouseBooks> { housebook }*/
                    }
                    );
                    context.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", YearOfPublishing = 2015, /*PublicationHouses = new List<PublicationHouseBooks> { housebook }*/ });
                    context.Books.Add(book);
                }
                if (!context.Magazines.Any())
                {
                    context.Magazines.Add(new Magazine { Name = "Forbes", Number = 20, YearOfPublishing = 2012 });
                    context.Magazines.Add(new Magazine { Name = "Biography", Number = 10, YearOfPublishing = 1960 });
                    context.Magazines.Add(new Magazine { Name = "Times", Number = 9, YearOfPublishing = 1880 });
                }
                if (!context.Brochures.Any())
                {
                    context.Brochures.Add(new Brochure { Name = "asd", TypeOfCover = TypeOfCover.Soft, NumberOfPages = 123 });
                }
                if (!context.PublicationHouses.Any())
                {
                    context.PublicationHouses.Add(house);
                    context.PublicationHouses.Add(new PublicationHouse { Name = "asd", Adress = "asd", /*Books = new List<Book> { book }*/ });
                }

                context.SaveChanges();
            }
        }
    }
}


