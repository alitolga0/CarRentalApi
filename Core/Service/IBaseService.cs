using CarRentalApi.Core.Utilities.Results;
using System.Linq.Expressions;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Core.Service
{
    public interface IBaseService<T, I>
    {
        Task<IResult> Add(T entity);
        Task<IResult> Delete(I id);
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        IDataResult<T> GetById(I id);
        Task<IResult> Update(T entity);
    }
}
