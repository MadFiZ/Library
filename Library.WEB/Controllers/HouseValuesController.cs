using Library.BLL.Interfaces;
using Library.BLL.Service;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Produces("application/json")]
[Route("api/housevalues")]
public class HouseValuesController : Controller
{
    private readonly AdditionalService _additionalService;
    private readonly IService<BookViewModel> _bookService;
    private readonly IService<PublicationHouseViewModel> _houseService;

    public HouseValuesController(IService<BookViewModel> bookService, IService<PublicationHouseViewModel> houseService, AdditionalService additionalService)
    {
        _additionalService = additionalService;
        _bookService = bookService;
        _houseService = houseService;
    }

    [HttpGet]
    public IEnumerable<SelectHouseViewModel> GetPublicationHouses()
    {
        var data = _houseService.GetItems();
        var houses = new List<SelectHouseViewModel>();
        foreach (var house in data)
        {
            houses.Add(new SelectHouseViewModel() { Id = house.Id, Name = house.Name });
        }
        return houses;
    }
}
