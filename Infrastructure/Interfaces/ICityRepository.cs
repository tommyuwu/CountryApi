using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCities();
        Task<City?> GetCityById(long id);
        Task<List<City>> GetCitiesByCountryId(long countryId);
        Task AddCity(City city);
        Task UpdateCity(City city);
        Task DeleteCity(long id);
    }
}