using Microsoft.EntityFrameworkCore;
using WorldCities.Models;

namespace WorldCities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<City>().HasKey(x => x.Id);
            modelBuilder.Entity<City>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<City>()
                        .Property(x => x.Lat)
                        .HasColumnType("decimal(7,4)");
            modelBuilder.Entity<City>()
                        .Property(x => x.Lon)
                        .HasColumnType("decimal(7,4)");

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Country>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<City>().HasOne(x => x.Country)
                .WithMany(y => y.Cities).HasForeignKey(x => x.CountryId);
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}