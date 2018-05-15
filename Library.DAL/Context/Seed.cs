using Library.Enums.Enums;
using Library.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
                if (!context.Books.Any())
                {
                    var books = new[]
           {
                new Book
                    {
                        Name = "Отцы и дети",
                        Author = "И. Тургенев",
                        YearOfPublishing = 2016
                },

            new Book { Name = "Чайка", Author = "А. Чехов", YearOfPublishing = 2015 },
                        new Book
                {
                    Name = "Война и мир",
                    Author = "Л. Толстой",
                    YearOfPublishing = 1998
                }
                    };
                }
                if (!context.PublicationHouses.Any())
                {
                    var houses = new[]
                    {
                        new PublicationHouse
                {
                    Name = "qwerty",
                    Adress = "Tales-Street"
                },
                        new PublicationHouse { Name = "asd", Adress = "asd" }
                };
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


                context.SaveChanges();
            }
        }
    }
}


