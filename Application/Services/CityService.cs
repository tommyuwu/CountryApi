using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class CityService(ICityRepository cityRepository) : ICityService
    {
        private readonly ICityRepository _cityRepository = cityRepository;

        public async Task AddCity(City city)
        {
            await _cityRepository.AddCity(city);
        }

        public async Task DeleteCity(long id)
        {
            await _cityRepository.DeleteCity(id);
        }

        public async Task<List<City>> GetAllCities()
        {
            return await _cityRepository.GetAllCities();
        }

        public async Task<List<City>> GetCitiesByCountryId(long countryId)
        {
            return await _cityRepository.GetCitiesByCountryId(countryId);
        }

        public Task<City?> GetCityById(long id)
        {
            return _cityRepository.GetCityById(id);
        }

        public async Task UpdateCity(City city)
        {
            await _cityRepository.UpdateCity(city);
        }

        private static CityDTO MapToCityDTO(City city)
        {
            return new CityDTO
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = city.CountryId,
            };
        }
    }
}
