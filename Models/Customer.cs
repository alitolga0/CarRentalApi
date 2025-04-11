namespace CarRentalApi.Models
{
    public class Customer : User
    {
        public string Address { get; set; }
        public ICollection<Rental> RentalHistory { get; set; }

    }
}
