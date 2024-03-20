using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country?> GetCountryById(long id);
        Task AddCountry(Country country);
        Task UpdateCountry(Country country);
        Task DeleteCountry(long id);
    }
}