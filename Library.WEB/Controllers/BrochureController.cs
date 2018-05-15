using Library.BLL.Interfaces;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/brochures")]
    public class BrochureController : Controller
    {
        private readonly IService<BrochureViewModel> _brochureService;

        public BrochureController(IService<BrochureViewModel> brochureService)
        {
            _brochureService = brochureService;
        }

        [HttpGet]
        public IEnumerable<BrochureViewModel> GetBrochures()
        {
            var brochures = _brochureService.GetItems();
            return brochures;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrochure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brochure = await _brochureService.GetItemAsync(id);

            if (brochure == null)
            {
                return NotFound();
            }

            return Ok(brochure);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrochure([FromRoute] int id, [FromBody] BrochureViewModel brochure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brochure.Id)
            {
                return BadRequest();
            }

            try
            {
                await _brochureService.UpdateAsync(brochure);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrochureExists(id))
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
        public async Task<IActionResult> PostBrochure([FromBody]BrochureViewModel brochure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _brochureService.InsertAsync(brochure);
            return Ok(brochure);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrochure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brochure = _brochureService.GetItem(id);
            if (brochure == null)
            {
                return NotFound();
            }
            await _brochureService.DeleteAsync(id);
            return Ok(brochure);
        }

        private bool BrochureExists(int id)
        {
            return _brochureService.GetItems().Any(e => e.Id == id);
        }
    }
}
