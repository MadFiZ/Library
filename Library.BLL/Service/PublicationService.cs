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
                PublicationViewModel publication = new PublicationViewModel() { Name = book.Name, Type = ty} 
                publications.Add()
            }
            var brochures = _brochureService.GetItems();
            publications.AddRange(brochures);
            var magazines = _magazineService.GetItems();
            publications.AddRange(magazines);
            return publications;
        }
    }
}
