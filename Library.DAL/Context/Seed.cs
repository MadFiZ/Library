using Library.Enums.Enums;
using Library.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library.DAL.Context
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var books = new[]
                {
                    new Book
                    {
                        Name = "Отцы и дети",
                        Author = "И. Тургенев",
                        YearOfPublishing = 2016
                    },
                    new Book
                    {
                        Name = "Чайка",
                        Author = "А. Чехов",
                        YearOfPublishing = 2015
                    },
                    new Book
                    {
                        Name = "Война и мир",
                        Author = "Л. Толстой",
                        YearOfPublishing = 1998
                    }
                };
                var houses = new[]
                {
                    new PublicationHouse
                    {
                        Name = "qwerty",
                        Adress = "Tales-Street"
                    },
                    new PublicationHouse
                    {
                        Name = "asd",
                        Adress = "asd"
                    }
                };
                var magazines = new[]
                {
                    new Magazine
                    {
                        Name = "Forbes",
                        Number = 20,
                        YearOfPublishing = 2012
                    },
                    new Magazine
                    {
                        Name = "Biography",
                        Number = 10,
                        YearOfPublishing = 1960
                    },
                    new Magazine
                    {
                        Name = "Times",
                        Number = 9,
                        YearOfPublishing = 1880
                    }
                };
                var brochures = new[]
                {
                    new Brochure
                    {
                        Name = "asd",
                        TypeOfCover = TypeOfCover.Soft,
                        NumberOfPages = 123
                    }
                };
                books[0].PublicationHouses.Add(houses[0]);
                books[1].PublicationHouses.Add(houses[1]);
                context.Books.AddRange(books);
                context.PublicationHouses.AddRange(houses);
                context.Magazines.AddRange(magazines);
                context.Brochures.AddRange(brochures);
                context.SaveChanges();
            }
        }
    }
}


