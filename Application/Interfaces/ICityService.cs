using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICityService
    {
        Task<CityDTO> CrearCiudad(int paisId, string nombre);
        Task<IEnumerable<CityDTO>> ObtenerCiudades(int paisId);
        Task<CityDTO> ObtenerCiudadPorId(int id);
        Task EditarCiudad(int id, string nombre);
        Task EliminarCiudad(int id);
    }
}
