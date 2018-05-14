using Library.BLL.Service;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/publications")]
    public class PublicationController : Controller
    {
        private readonly PublicationService _libraryService;

        public PublicationController(PublicationService publicationService)
        {
            _libraryService = publicationService;
        }

        [HttpGet]
        public IEnumerable<PublicationViewModel> GetBooks()
        {
            var data = _libraryService.GetPublications().ToList();
            return data;
        }

    }
}