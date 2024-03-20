using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Paises { get; set; }
        public DbSet<City> Ciudades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .ToTable("Paises")
                .HasKey(p => p.Id);

            modelBuilder.Entity<City>()
                .ToTable("Ciudades")
                .HasKey(c => c.Id)
                .HasOne(c => c.C)
                .WithMany(p => p.Ciudades)
                .HasForeignKey(c => c.PaisId);
        }
    }

}
