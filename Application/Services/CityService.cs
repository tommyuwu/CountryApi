using Application.Interfaces;

namespace Application.Services
{
    public class CiudadService : ICityService
    {
        private readonly ICiudadRepository _ciudadRepository;

        public CiudadService(ICiudadRepository ciudadRepository)
        {
            _ciudadRepository = ciudadRepository;
        }

        public async Task<CiudadDTO> CrearCiudad(int paisId, string nombre)
        {
            // Validar nombre de la ciudad
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre de la ciudad es obligatorio.");
            }

            var ciudad = new Ciudad { Nombre = nombre, PaisId = paisId };
            await _ciudadRepository.AddAsync(ciudad);
            await _ciudadRepository.SaveChangesAsync();

            return await MapearACiudadDTO(ciudad);
        }

        // ... otros métodos de la interfaz ICiudadService

        private async Task<CiudadDTO> MapearACiudadDTO(Ciudad ciudad)
        {
            // Mapear las propiedades de Ciudad a CiudadDTO
            return new CiudadDTO
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                PaisId = ciudad.PaisId,
            };
        }
    }

}
