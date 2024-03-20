using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CountriesController(ICountryService countryService) : Controller
    {
        private readonly ICountryService _countryService = countryService;

        
    }
}