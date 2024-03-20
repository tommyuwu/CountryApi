namespace Domain.Entities
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
