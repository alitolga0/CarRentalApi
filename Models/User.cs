using Microsoft.AspNetCore.Identity;

namespace CarRentalApi.Models
{
    public class User : IdentityUser<Guid>
    {
        public bool? IsDeleted { get; set; }

        public UserDetail? UserDetail { get; set; }
    }
}
