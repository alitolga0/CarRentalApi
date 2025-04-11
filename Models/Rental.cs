namespace CarRentalApi.Models
{
    public class Rental : BaseEntity
    {
        public RentalStatus Status { get; set; }
        public Double Price { get; set; }
        public Guid CarId { get; set; }  
        public Guid CustomerId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Car? Car { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
public enum RentalStatus
{
    Pending, 
    Active, 
    Completed,
    Cancelled 
}