using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class CountriesController(ICountryService countryService) : Controller
    {
        private readonly ICountryService _countryService = countryService;

        [HttpGet("country")]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await _countryService.GetAllCountries());
        }

        [HttpGet("country/{id}")]
        public async Task<IActionResult> GetCountryById([FromRoute] long id)
        {
            return Ok(await _countryService.GetCountryById(id));
        }

        [HttpPost("country")]
        public async Task<IActionResult> CreateCountry([FromBody] Country country)
        {
            await _countryService.AddCountry(country);
            return Ok();
        }

        [HttpPut("country")]
        public async Task<IActionResult> UpdateCountry([FromBody] Country country)
        {
            await _countryService.UpdateCountry(country);
            return Ok();
        }

        [HttpDelete("country/{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] long id)
        {
            await _countryService.DeleteCountry(id);
            return Ok();
        }
    }
}