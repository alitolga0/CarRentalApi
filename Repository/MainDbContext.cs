using CarRentalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Repository
{
    public class MainDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Car>()
              .Property(x => x.LicenseLate).IsRequired(true);

            builder.Entity<Car>()
                .HasOne(b => b.Brand)
                .WithMany(c => c.Cars)
                .HasForeignKey(b => b.BrandId);

            builder.Entity<Car>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(b => b.CategoryId);


            builder.Entity<Brand>()
              .Property(x => x.Name).IsRequired(true);

            builder.Entity<Category>()
                 .Property(x => x.Name).IsRequired(true);
        }
    }
}

