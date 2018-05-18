using AutoMapper;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System.Collections.Generic;

namespace Library.BLL.Service
{
    public class AdditionalService
    {
        private IRepository<Book> _bookRepository;
        private readonly IRepository<PublicationHouse> _houseRepository;

        public AdditionalService(IRepository<Book> bookRepository, IRepository<PublicationHouse> houseRepository)
        {
            _bookRepository = bookRepository;
            _houseRepository = houseRepository;
        }

        public string GetPublicationHouseNames(ICollection<PublicationHouseViewModel> publicationHouses)
        {
            string houses = string.Empty;
            foreach (var house in publicationHouses)
            {
                houses += $"{house.Name}; ";
            }
            return houses;
        }

        /*public IList<PublicationHouseViewModel> GetPublicationHouses(BookViewModel book)
        {
            List<PublicationHouseViewModel> houses = new List<PublicationHouseViewModel>();
            foreach(var house in book.PublicationHouses)
            {
                houses.Add(house.PublicationHouse);
            }
            return houses;
        }*/

        public BookViewModel GetBookForEdit(int id)
        {
            var book = _bookRepository.Get(id);
            var editBook = Mapper.Map<Book, BookViewModel>(book);
            return editBook;
        }


        /*public string GetBooksNames(ICollection<HouseBookViewModel> booksView)
        {
            try
            {
                string books = string.Empty;
                foreach (var book in booksView)
                {
                    books += $"{book.Book.Name}; ";
                }
                return books;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }*/
    }
}
