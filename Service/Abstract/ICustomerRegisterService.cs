using CarRentalApi.Core.Service;
using CarRentalApi.Models;

namespace CarRentalApi.Service.Abstract
{
    public interface ICustomerRegisterService : IBaseService<Register, Guid>
    {
    }
}
