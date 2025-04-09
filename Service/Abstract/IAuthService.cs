using CarRentalApi.Models;

namespace CarRentalApi.Service.Abstract
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}
