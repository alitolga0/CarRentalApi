using CarRentalApi.Models;

public class UserDetail : BaseEntity
{
    public Guid UserId { get; set; }
    public string Address { get; set; }
    public User? User { get; set; }
}
