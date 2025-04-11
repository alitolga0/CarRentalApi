namespace CarRentalApi.Models
{
    public class Seller : UserDetail
    {
        public long Vkn { get; set; }
        public string CompanyName { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
