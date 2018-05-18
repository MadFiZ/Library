using Library.DAL.Context;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Repository
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(LibraryContext context) : base(context)
        { }
             public override IQueryable<Book> GetAll()
        {
            try
            {
                var books = _entities
                    .Include("PublicationHouseBooks.PublicationHouse");
                return books;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override async Task<ICollection<Book>> GetAllAsync()
        {
            try
            {
                var books = _entities
                   .Include("PublicationHouseBooks.PublicationHouse")
                   .ToListAsync();
                return await books;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override Book Get(int id)
        {
            try
            {
                var book = _entities
                    .Include("PublicationHouseBooks.PublicationHouse")
                    .ToList()
                    .Find(b => b.Id == id);
                return book;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override void Add(Book bookToAdd)
        {
            try
            {
                if (bookToAdd == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var book = Get(bookToAdd.Id);
                book.PublicationHouses.Clear();
                foreach (var house in bookToAdd.PublicationHouses)
                {
                    book.PublicationHouses.Add(house);
                }
                _entities.Add(book);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override async Task<bool> AddAsync(Book bookToAdd)
        {
            try
            {
                if (bookToAdd == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _entities.Add(bookToAdd);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public override void Update(Book book, object key)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Book exist = Get(Convert.ToInt32(key));
                if (exist != null)
                {
                    exist.PublicationHouses.Clear();
                    foreach (var house in book.PublicationHouses)
                    {
                        exist.PublicationHouses.Add(house);
                    }
                    _context.Entry(exist).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override async Task<bool> UpdateAsync(Book book, object key)
        {
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Book exist = Get(Convert.ToInt32(key));
                if (exist != null)
                {
                    foreach (var property in exist.GetType().GetProperties())
                    {
                        if (property.Name != "Id" && !property.GetGetMethod().IsVirtual)
                        {
                            property.SetValue(exist, property.GetValue(book));
                        }
                    }
                    exist.PublicationHouses.Clear();
                    foreach (var house in book.PublicationHouses)
                    {
                        exist.PublicationHouses.Add(house);
                    }
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override void Delete(Book book)
        {
            try
            {
                book.PublicationHouses.Clear();
                _entities.Remove(book);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override async Task<bool> DeleteAsync(Book book)
        {
            try
            {
                book.PublicationHouses.Clear();
                _entities.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
