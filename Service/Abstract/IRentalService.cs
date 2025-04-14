using CarRentalApi.Core.Service;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;

namespace CarRentalApi.Service.Abstract
{
    public interface IRentalService : IBaseService <Rental, Guid>
    {
        IDataResult<List<Rental>> GetAllBeforeNow();
    }
}
