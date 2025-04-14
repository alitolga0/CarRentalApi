using CarRentalApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CarRentalApi.Repository
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<UserDetail>()
              .ToTable("user_details")
              .HasOne(ud => ud.User)
              .WithOne(u => u.UserDetail)
              .HasForeignKey<UserDetail>(ud => ud.UserId);

            builder.Entity<Adress>()
                .HasOne(a => a.UserDetail)
                .WithMany(ud => ud.Adresses)
                .HasForeignKey(a => a.UserDetailId);

            builder.Entity<Seller>().ToTable("user_details")
                .HasBaseType<UserDetail>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Seller>("Seller");

            builder.Entity<Customer>().ToTable("user_details")
                .HasBaseType<UserDetail>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Customer>("Customer");

            builder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId);

            builder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Cars)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<Car>()
                .HasOne(c => c.Seller)
                .WithMany(s => s.Cars)
                .HasForeignKey(c => c.SellerId); 

            builder.Entity<Rental>()
               .HasOne(r => r.Car)
               .WithMany(c => c.Rentals)
               .HasForeignKey(r => r.CarId);

            builder.Entity<Rental>()
               .HasOne(r => r.Customer)
               .WithMany(c => c.Rentals)
               .HasForeignKey(r => r.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

            ConfigureCar(builder);
            ConfigureCustomer(builder);
            ConfigureSeller(builder);

            builder.Entity<Brand>()
               .Property(x => x.Name).IsRequired(true);

            builder.Entity<Category>()
               .Property(x => x.Name).IsRequired(true);

            SeedRoles(builder);
        }
        
        private static void ConfigureCar(ModelBuilder builder)
        {
            builder.Entity<Car>(x =>
            {
                x.Property(p=> p.LicensePlate).IsRequired(true);
                x.Property(p => p.Year).IsRequired(true);
                x.Property(p => p.Availability).IsRequired(true);
                x.Property(p => p.DailyPrice).IsRequired(true);
                x.Property(p => p.SellerId).IsRequired(true);
                x.Property(p => p.CategoryId).IsRequired(true);
                x.Property(p => p.BrandId).IsRequired(true);
            });
        }

        private static void ConfigureCustomer(ModelBuilder builder)
        {
            builder.Entity<Customer>(x =>
            {
                x.Property(p => p.Tckn).IsRequired(true);
                x.Property(p => p.FirstName).IsRequired(true);
                x.Property(p => p.LastName).IsRequired(true);
            });
           
        }

        private static void ConfigureSeller(ModelBuilder builder)
        {
            builder.Entity<Seller>(x =>
            {
                x.Property(p => p.CompanyName).IsRequired(true);
                x.Property(p => p.Vkn).IsRequired(true);
            });
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    ConcurrencyStamp = "1",
                    Name = "Seller",
                    NormalizedName = "SELLER"
                },
                new IdentityRole
                {
                    Id = "2",
                    ConcurrencyStamp = "2",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Id = "3",
                    ConcurrencyStamp = "3",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
