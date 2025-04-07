using CarRentalApi.Core.Service;
using CarRentalApi.Models;

namespace CarRentalApi.Service.Abstract
{
    public interface ICarService : IBaseService<Car, Guid>
    {
    }
}
