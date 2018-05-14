using Library.BLL.Interfaces;
using Library.ViewModels.ViewModels;
using System.Collections.Generic;

namespace Library.BLL.Service
{
    public class PublicationService
    {
        private IService<BookViewModel> _bookService;
        private IService<BrochureViewModel> _brochureService;
        private IService<MagazineViewModel> _magazineService;

        public PublicationService(IService<BookViewModel> bookService, IService<BrochureViewModel> brochureService, IService<MagazineViewModel> magazineService)
        {
            _bookService = bookService;
            _brochureService = brochureService;
            _magazineService = magazineService;
        }

        public IEnumerable<PublicationViewModel> GetPublications()
        {
            List<PublicationViewModel> publications = new List<PublicationViewModel>();
            var books = _bookService.GetItems();
            foreach (var book in books)
            {
                PublicationViewModel publication = new PublicationViewModel() { Id = book.Id, Name = book.Name, Type = book.GetType().Name.Replace("ViewModel", "") };
                publications.Add(publication);
            }
            var brochures = _brochureService.GetItems();
            foreach (var brochure in brochures)
            {
                PublicationViewModel publication = new PublicationViewModel() { Id = brochure.Id, Name = brochure.Name, Type = brochure.GetType().Name.Replace("ViewModel", "") };
                publications.Add(publication);
            }
            var magazines = _magazineService.GetItems();
            foreach (var magazine in magazines)
            {
                PublicationViewModel publication = new PublicationViewModel() { Id = magazine.Id, Name = magazine.Name, Type = magazine.GetType().Name.Replace("ViewModel", "") };
                publications.Add(publication);
            }
            return publications;
        }
    }
}
