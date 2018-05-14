using Library.BLL.Interfaces;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var brochures = _brochureService.GetItems().ToList();
            return brochures;
        }

        [HttpGet("{id}")]
        public IActionResult GetBrochure([FromRoute] int id)
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

            return Ok(brochure);
        }


        [HttpPut("{id}")]
        public IActionResult PutBrochure([FromRoute] int id, [FromBody] BrochureViewModel brochure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brochure.Id)
            {
                return BadRequest();
            }
            _brochureService.Update(brochure);

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostBrochure([FromBody]BrochureViewModel brochure)
        {
            if (ModelState.IsValid)
            {
                _brochureService.Insert(brochure);
                return Ok(brochure);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrochure([FromRoute] int id)
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
            _brochureService.Delete(id);
            return Ok(brochure);
        }
    }
}
