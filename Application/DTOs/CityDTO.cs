namespace Application.DTOs
{
    public class CityDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required long CountryId { get; set; }
    }
}