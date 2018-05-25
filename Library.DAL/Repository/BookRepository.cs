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
                _entities.Add(bookToAdd);
                Save();
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
                await SaveAsync();
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
                Book exist = Get(book.Id);
                var houses = book.PublicationHouses;
                var existhouses = new List<PublicationHouse>();
                foreach (var house in exist.PublicationHouses)
                {
                    existhouses.Add(house);
                }
                if (exist != null)
                {
                    if (existhouses != null)
                    {
                        foreach (var oldHouse in existhouses)
                        {
                            var existHouse = book.PublicationHouses.Contains(oldHouse);
                            if (existHouse == false)
                            {
                                exist.PublicationHouses.Remove(oldHouse);
                            }
                            if (existHouse == true)
                            {
                                houses.Remove(oldHouse);
                            }
                        }
                        if (houses.Count != 0)
                        {
                            foreach (var house in houses)
                            {
                                exist.PublicationHouses.Add(house);
                            }
                        }
                    }
                    if (existhouses == null)
                    {
                        foreach (var house in houses)
                        {
                            exist.PublicationHouses.Add(house);
                        }
                    }
                    _context.Entry(exist).CurrentValues.SetValues(book);
                    Save();
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
                Book exist = Get(book.Id);
                var houses = book.PublicationHouses;
                var existhouses = new List<PublicationHouse>();
                foreach(var house in exist.PublicationHouses)
                {
                    existhouses.Add(house);
                }
                if (exist != null)
                {
                    if (existhouses != null)
                    {
                        foreach (var oldHouse in existhouses)
                        {
                            var existHouse = book.PublicationHouses.Contains(oldHouse);
                            if (existHouse == false)
                            {
                                exist.PublicationHouses.Remove(oldHouse);
                            }
                            if (existHouse == true)
                            {
                                houses.Remove(oldHouse);
                            }  
                    }
                        if (houses.Count != 0)
                        {
                            foreach (var house in houses)
                            {
                                exist.PublicationHouses.Add(house);
                            }
                        }
                    }
                    if (existhouses == null)
                    {
                        foreach(var house in houses)
                        {
                            exist.PublicationHouses.Add(house);
                        }
                    }
                    _context.Entry(exist).CurrentValues.SetValues(book);
                    await SaveAsync();
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
                Save();
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
                await SaveAsync();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
