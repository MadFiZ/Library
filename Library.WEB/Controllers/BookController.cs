using Library.BLL.Interfaces;
using Library.BLL.Service;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly AdditionalService _additionalService;
        private readonly IService<BookViewModel> _bookService;
        private readonly IService<PublicationHouseViewModel> _houseService;

        public BookController(IService<BookViewModel> bookService, IService<PublicationHouseViewModel> houseService, AdditionalService additionalService)
        {
            _additionalService = additionalService;
            _bookService = bookService;
            _houseService = houseService;
        }

        [HttpGet]
        public IEnumerable<BookViewModel> GetBooks()
        {
            var books = _bookService.GetItems();
            return books;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _bookService.GetItemAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /*public ActionResult GetBooks()
        {
            var data = _bookService.GetItems().OrderByDescending(b => b.Name).Select(b => new
            {
                ID = b.Id,
                b.Name,
                b.Author,
                b.YearOfPublishing,
                PublicationHouses = _additionalService.GetPublicationHouseNames(b.PublicationHouses)
            }).ToList();
            return Json(data);
        }*/

        public ActionResult GetPublicationHouses()
        {
            var data = _houseService.GetItems().OrderByDescending(p => p.Name).Select(p => new
            {
                p.Id,
                p.Name
            }).ToList();
            return Json(data);
        }

        /*public ActionResult GetBookPublicationHouses(int bookId)
        {
            var book = _bookService.GetItem(bookId);
            var data = book.PublicationHouses.Select(p => p.PublicationHouseId).ToList();
            return Json(data);
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromRoute] int id, [FromBody] BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            try
            {
                await _bookService.UpdateAsync(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody]BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _bookService.InsertAsync(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = _bookService.GetItem(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteAsync(id);
            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return _bookService.GetItems().Any(e => e.Id == id);
        }
    }
}
