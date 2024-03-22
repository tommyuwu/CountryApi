using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class CountryService(ICountryRepository countryRepository) : ICountryService
    {
        private readonly ICountryRepository _countryRepository = countryRepository;

        public async Task AddCountry(Country country)
        {
            await _countryRepository.AddCountry(country);
        }

        public async Task DeleteCountry(long id)
        {
            await _countryRepository.DeleteCountry(id);
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _countryRepository.GetAllCountries();
        }

        public async Task<Country?> GetCountryById(long id)
        {
            return await _countryRepository.GetCountryById(id);
        }

        public async Task UpdateCountry(Country country)
        {
            await _countryRepository.UpdateCountry(country);
        }

        private static CountryDTO MapToCountryDTO(Country country)
        {
            return new CountryDTO
            {
                Id = country.Id,
                Name = country.Name,
            };
        }
    }
}
