namespace CarRentalApi.Models
{
    public class Seller : User
    {
        public List<Car> CarsForRent { get; set; }
        public string CompanyName { get; set; }
    }
}
