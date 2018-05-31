using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.DAL.Repository;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL.Service
{
    public class BookService : IService<BookViewModel>
    {
        private IRepository<Book> _bookRepository;
        private readonly IRepository<PublicationHouse> _houseRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<PublicationHouse> houseRepository)
        {
            _bookRepository = bookRepository;
            _houseRepository = houseRepository;
        }

        private string GetPublicationHouseNames(ICollection<PublicationHouse> publicationHouses)
        {
            string houses = string.Empty;
            foreach (var house in publicationHouses)
            {
                houses += $"{house.Name} ";
            }
            return houses;
        }

        private string GetPublicationHouseIds(ICollection<PublicationHouse> publicationHouses)
        {
           string housesId = string.Empty;
            foreach (var house in publicationHouses)
            {
                housesId +=$"{house.Id} ";
            }
            return housesId;
        }

        public IEnumerable<BookViewModel> GetItems()
        {
            try
            {
                var booksFromDb = _bookRepository.GetAll();
                var books =
                Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(booksFromDb);
                foreach (var book in books)
                {
                    var bookWithHouses = _bookRepository.Get(book.Id);
                    book.PublicationHouseIds = GetPublicationHouseIds(bookWithHouses.PublicationHouses);
                    book.PublicationHouseNames = GetPublicationHouseNames(bookWithHouses.PublicationHouses);
                }
                return books;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetItemsAsync()
        {
            try
            {
                var booksFromDb = await _bookRepository.GetAllAsync();
                var books =
                   Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(booksFromDb);
                foreach (var book in books)
                {
                    var bookWithHouses = _bookRepository.Get(book.Id);
                    book.PublicationHouseIds = GetPublicationHouseIds(bookWithHouses.PublicationHouses);
                    book.PublicationHouseNames = GetPublicationHouseNames(bookWithHouses.PublicationHouses);
                }
                return books;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public BookViewModel GetItem(int id)
        {
            try
            {
                var bookFromDb = _bookRepository.Get(id);
                var book = Mapper.Map<Book, BookViewModel>(bookFromDb);
                book.PublicationHouseIds = GetPublicationHouseIds(bookFromDb.PublicationHouses);
                book.PublicationHouseNames = GetPublicationHouseNames(bookFromDb.PublicationHouses);
                return book;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<BookViewModel> GetItemAsync(int id)
        {
            try
            {
                var bookFromDb = await _bookRepository.GetAsync(id);
                var book = Mapper.Map<Book, BookViewModel>(bookFromDb);
                book.PublicationHouseIds = GetPublicationHouseIds(bookFromDb.PublicationHouses);
                book.PublicationHouseNames = GetPublicationHouseNames(bookFromDb.PublicationHouses);
                return book;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private string[] GetPublicationHousesByIds(string publicationHouses)
        {
            var houses = publicationHouses.Split(' ');
            return houses;
        }

        public int Insert(BookViewModel addBook)
        {
            try
            {
                var bookToAdd = Mapper.Map<BookViewModel, Book>(addBook);
                var houses = _houseRepository.GetAll().ToList();
                var housesToAdd = GetPublicationHousesByIds(addBook.PublicationHouseIds);
                foreach (var house in housesToAdd)
                {
                    if (house != "")
                    {
                        bookToAdd.PublicationHouses.Add(houses.Find(h => h.Id == Convert.ToInt32(house)));
                    }
                }
                return _bookRepository.Add(bookToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<int> InsertAsync(BookViewModel addBook)
        {
            try
            {
                var bookToAdd = Mapper.Map<BookViewModel, Book>(addBook);
                var houses = _houseRepository.GetAll().ToList();
                var housesToAdd = GetPublicationHousesByIds(addBook.PublicationHouseIds);
                foreach (var house in housesToAdd)
                {
                    if (house != "")
                    {
                        bookToAdd.PublicationHouses.Add(houses.Find(h => h.Id == Convert.ToInt32(house)));
                    }
                }
                return await _bookRepository.AddAsync(bookToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update(BookViewModel updateBook)
        {
            try
            {
                var bookToUpdate = Mapper.Map<BookViewModel, Book>(updateBook);
                var houses = _houseRepository.GetAll().ToList();
                var housesToAdd = GetPublicationHousesByIds(updateBook.PublicationHouseIds);
                foreach (var house in housesToAdd)
                {
                    if (house != "")
                    {
                        bookToUpdate.PublicationHouses.Add(houses.Find(h => h.Id == Convert.ToInt32(house)));
                    }
                }
                _bookRepository.Update(bookToUpdate, bookToUpdate.Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> UpdateAsync(BookViewModel updateBook)
        {
            try
            {
                var bookToUpdate = Mapper.Map<BookViewModel, Book>(updateBook);
                var houses = _houseRepository.GetAll().ToList();
                var housesToAdd = GetPublicationHousesByIds(updateBook.PublicationHouseIds);
                foreach (var house in housesToAdd)
                {
                    if (house != "")
                    {
                        bookToUpdate.PublicationHouses.Add(houses.Find(h => h.Id == Convert.ToInt32(house)));
                    }
                }
                bool success = await _bookRepository.UpdateAsync(bookToUpdate, bookToUpdate.Id);
                if (success == true)
                {
                    return true;
                }
                return false;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public void Delete(int id)
        {
            try
            {
                Book book = _bookRepository.Get(id);
                _bookRepository.Delete(book);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Book book = _bookRepository.Get(id);
                bool success = await _bookRepository.DeleteAsync(book);
                if (success == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

