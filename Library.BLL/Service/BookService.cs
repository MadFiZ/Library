using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System.Collections.Generic;

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
            var booksFromDb = _bookRepository.GetAll();
            var books =
               Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(booksFromDb);
            return books;
        }

        public BookViewModel GetItem(int id)
        {
            var bookFromDb = _bookRepository.Get(id);
            var book = Mapper.Map<Book, BookViewModel>(bookFromDb);
            return book;
        }

        public void Insert(BookViewModel addBook)
        {
                var bookToAdd = Mapper.Map<BookViewModel, Book>(addBook);            
                _bookRepository.Insert(bookToAdd);
        }

        public void Update(BookViewModel book)
        {
            var bookToUpdate = Mapper.Map<BookViewModel, Book>(book);
            _bookRepository.Update(bookToUpdate);
        }

        public void Delete(int id)
        {
            Book book = _bookRepository.Get(id);
            _bookRepository.Remove(book);
        }
    }
}

