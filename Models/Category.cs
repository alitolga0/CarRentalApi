namespace CarRentalApi.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
