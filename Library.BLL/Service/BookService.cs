using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
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

        public IEnumerable<BookViewModel> GetItems()
        {
            try
            {
                var booksFromDb = _bookRepository.GetAll();
                var books =
                   Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(booksFromDb);
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
            return book;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Insert(BookViewModel addBook)
        {
            try
            {
                var bookToAdd = Mapper.Map<BookViewModel, Book>(addBook);
                _bookRepository.Add(bookToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> InsertAsync(BookViewModel addBook)
        {
            try
            {
                var bookToAdd = Mapper.Map<BookViewModel, Book>(addBook);
                bool success = await _bookRepository.AddAsync(bookToAdd);
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

        public void Update(BookViewModel book)
        {
            try
            {
                var bookToUpdate = Mapper.Map<BookViewModel, Book>(book);
                _bookRepository.UpdateAsync(bookToUpdate, bookToUpdate.Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> UpdateAsync(BookViewModel book)
        {
            try
            {
                var bookToUpdate = Mapper.Map<BookViewModel, Book>(book);
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
                _bookRepository.DeleteAsync(book);
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

