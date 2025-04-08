namespace CarRentalApi.Models
{
    public class Rental : BaseEntity
    {
        public RentalStatus Status { get; set; }
        public Guid CarId { get; set; }  
        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Car? Car { get; set; }
        public virtual User? User { get; set; }
       
        

    }
}
public enum RentalStatus
{
    Pending, 
    Active, 
    Completed,
    Cancelled 
}