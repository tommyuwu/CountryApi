using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CountryRepository(ApplicationDbContext context) : ICountryRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Country>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetCountryById(long id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task AddCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCountry(Country country)
        {
            var countryToUp = _context.Countries.Find(country.Id);
            if (countryToUp != null)
            {
                _context.Countries.Update(countryToUp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCountry(long id)
        {
            var country = _context.Countries.Find(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
        }
    }
}