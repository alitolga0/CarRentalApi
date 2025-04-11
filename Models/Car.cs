namespace CarRentalApi.Models
{
    public class Car : BaseEntity
    {
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public Double DailyPrice { get; set; } //TODO: Price table should be created and related with car.
        public bool Availability { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SellerId { get; set; }
        public Brand? Brand { get; set; }  
        public Category? Category { get; set; }
        public Seller? Seller { get; set; }
        public List<Rental>? Rentals { get; set; }

    }
}
