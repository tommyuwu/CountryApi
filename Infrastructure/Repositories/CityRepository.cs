using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CityRepository(ApplicationDbContext context) : ICityRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City?> GetCityById(long id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<List<City>> GetCitiesByCountryId(long countryId)
        {
            return await _context.Cities.Where(c => c.CountryId == countryId).ToListAsync();
        }

        public async Task AddCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCity(City city)
        {
            var cityToUp = _context.Cities.Find(city.Id);
            if (cityToUp != null)
            {
                _context.Cities.Remove(cityToUp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCity(long id)
        {
            var city = _context.Cities.Find(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }
        }
    }
}