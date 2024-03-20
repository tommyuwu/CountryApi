using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CityController(ICityService cityService) : Controller
    {
        private readonly ICityService _cityService = cityService;

        [HttpGet("city")]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await _cityService.GetAllCities());
        }
    }
}
