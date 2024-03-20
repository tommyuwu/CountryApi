using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICountryService
    {
        Task<CountryDTO> CrearPais(string nombre);
        Task<IEnumerable<CountryDTO>> ObtenerPaises();
        Task<CountryDTO> ObtenerPaisPorId(int id);
        Task EditarPais(int id, string nombre);
        Task EliminarPais(int id);
    }
}
