﻿using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountries();
        Task<Country?> GetCountryById(long id);
        Task AddCountry(Country country);
        Task UpdateCountry(Country country);
        Task DeleteCountry(long id);
    }
}
