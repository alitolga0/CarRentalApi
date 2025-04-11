using Microsoft.AspNetCore.Identity;

namespace CarRentalApi.Models
{
    public class User : IdentityUser<Guid>
    {
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Car> Cars { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
    public enum UserRole
    {
        Customer = 0,
        Seller = 1,
        Admin = 2
    }

}
