namespace CarRentalApi.Models
{
    public class Admin : User
    {
        public string AdminCode { get; set; }
        public string Permissions { get; set; }
    }
}
