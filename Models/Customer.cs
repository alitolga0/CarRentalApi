namespace CarRentalApi.Models
{
    public class Customer : UserDetail
    {
        public long Tckn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
