namespace CarRentalApi.Models
{
    public class Adress : BaseEntity
    {
       
        public string Address { get; set; }
        public Guid UserDetailId { get; set; }  
        public UserDetail? UserDetail { get; set; }
    }
}
