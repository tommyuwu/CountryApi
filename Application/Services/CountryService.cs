using Application.Interfaces;

namespace Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public async Task<PaisDTO> CrearPais(string nombre)
        {
            // Validar nombre del país
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre del país es obligatorio.");
            }

            var pais = new Pais { Nombre = nombre };
            await _paisRepository.AddAsync(pais);
            await _paisRepository.SaveChangesAsync();

            return await MapearAPaisDTO(pais);
        }

        // ... otros métodos de la interfaz IPaisService

        private async Task<PaisDTO> MapearAPaisDTO(Pais pais)
        {
            // Mapear las propiedades de Pais a PaisDTO
            // Puedes usar librerías de mapeo automático ( AutoMapper )
            var ciudadesDTO = await _paisRepository.ObtenerCiudadesPorPaisId(pais.Id);
            return new PaisDTO
            {
                Id = pais.Id,
                Nombre = pais.Nombre,
                Ciudades = ciudadesDTO.Select(c => new CiudadDTO { Id = c.Id, Nombre = c.Nombre })
            };
        }
    }

}
