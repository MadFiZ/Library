using Library.BLL.Interfaces;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/magazines")]
    public class MagazineController : Controller
    {
        private readonly IService<MagazineViewModel> _magazineService;

        public MagazineController(IService<MagazineViewModel> magazineService)
        {
            _magazineService = magazineService;
        }

        [HttpGet]
        public IEnumerable<MagazineViewModel> GetMagazines()
        {
            var magazines = _magazineService.GetItems();
            return magazines;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMagazine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var magazine = await _magazineService.GetItemAsync(id);

            if (magazine == null)
            {
                return NotFound();
            }

            return Ok(magazine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazine([FromRoute] int id, [FromBody] MagazineViewModel magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != magazine.Id)
            {
                return BadRequest();
            }

            try
            {
                await _magazineService.UpdateAsync(magazine);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineExists(id))
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
        public async Task<IActionResult> PostMagazine([FromBody]MagazineViewModel magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _magazineService.InsertAsync(magazine);
            return Ok(magazine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var magazine = _magazineService.GetItem(id);
            if (magazine == null)
            {
                return NotFound();
            }
            await _magazineService.DeleteAsync(id);
            return Ok(magazine);
        }

        private bool MagazineExists(int id)
        {
            return _magazineService.GetItems().Any(e => e.Id == id);
        }
    }
}
