using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CityController(ICityService cityService) : Controller
    {
        private readonly ICityService _cityService = cityService;

        [HttpGet("city")]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await _cityService.GetAllCities());
        }

        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetCityById([FromRoute] long id)
        {
            return Ok(await _cityService.GetCityById(id));
        }

        [HttpGet("city/country/{id}")]
        public async Task<IActionResult> GetCitiesByCountryId([FromRoute] long id)
        {
            return Ok(await _cityService.GetCitiesByCountryId(id));
        }

        [HttpPost("city")]
        public async Task<IActionResult> CreateCity([FromBody] City city)
        {
            await _cityService.AddCity(city);
            return Ok();
        }

        [HttpPut("city")]
        public async Task<IActionResult> UpdateCity([FromBody] City city)
        {
            await _cityService.UpdateCity(city);
            return Ok();
        }

        [HttpDelete("city/{id}")]
        public async Task<IActionResult> DeleteCity([FromRoute] long id)
        {
            await _cityService.DeleteCity(id);
            return Ok();
        }
    }
}