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
    [Route("api/houses")]
    public class PublicationHouseController : Controller
    {
        private readonly IService<PublicationHouseViewModel> _houseService;

        public PublicationHouseController(IService<PublicationHouseViewModel> houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        public IEnumerable<PublicationHouseViewModel> GetPublicationHouses()
        {
            var houses = _houseService.GetItems();
            return houses;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicationHouse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var house = await _houseService.GetItemAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicationHouse([FromRoute] int id, [FromBody] PublicationHouseViewModel house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != house.Id)
            {
                return BadRequest();
            }

            try
            {
                await _houseService.UpdateAsync(house);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationHouseExists(id))
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
        public async Task<IActionResult> PostPublicationHouse([FromBody]PublicationHouseViewModel house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _houseService.InsertAsync(house);
            return Ok(house);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicationHouse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var house = _houseService.GetItem(id);
            if (house == null)
            {
                return NotFound();
            }
            await _houseService.DeleteAsync(id);
            return Ok(house);
        }

        private bool PublicationHouseExists(int id)
        {
            return _houseService.GetItems().Any(e => e.Id == id);
        }
    }
}
