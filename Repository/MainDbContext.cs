using CarRentalApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Repository
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
      .HasDiscriminator<string>("UserType")
      .HasValue<Admin>("Admin")
      .HasValue<Seller>("Seller")
      .HasValue<Customer>("Customer");

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

            builder.Entity<Car>()
                .HasMany(u => u.Users)
                .WithMany(c => c.Cars);

            builder.Entity<Rental>()
               .HasOne(c => c.Car)
               .WithMany(r => r.Rentals)
               .HasForeignKey(c => c.CarId);

            builder.Entity<Rental>()
               .HasOne(u => u.User)
               .WithMany(r => r.Rentals)
               .HasForeignKey(u => u.UserId);

            builder.Entity<Brand>()
              .Property(x => x.Name).IsRequired(true);

            builder.Entity<Category>()
                 .Property(x => x.Name).IsRequired(true);
        }
    }
}
