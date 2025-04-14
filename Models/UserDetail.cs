using CarRentalApi.Models;

public class UserDetail : BaseEntity
{
    public Guid UserId { get; set; }
    public List<Adress>? Adresses { get; set; }
    
    public User? User { get; set; }

}
