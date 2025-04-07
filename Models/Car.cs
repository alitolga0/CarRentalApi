namespace CarRentalApi.Models
{
    public class Car : BaseEntity
    {
        public int Year { get; set; }
        public string LicenseLate { get; set; }
        public Double DailyRate { get; set; }
        public bool Availability { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public Brand? Brand { get; set; }  
        public Category? Category { get; set; }

    }
}
