using CarRentalApi.Models;

public class UserDetail : User
{
    public string AdminCode { get; set; }  
    public List<string> Permissions { get; set; } 
    public List<Car> CarsForRent { get; set; }  
    public string CompanyName { get; set; }  
    public List<Rental> Rentals { get; set; }  
}
