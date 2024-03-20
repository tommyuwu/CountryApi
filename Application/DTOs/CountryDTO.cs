namespace Application.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CityDTO> Cities { get; set; }
    }
}
