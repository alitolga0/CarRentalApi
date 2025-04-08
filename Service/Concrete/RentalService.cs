using CarRentalApi.Core.Repository;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Repository;
using CarRentalApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Service.Concrete
{
    public class RentalService : IRentalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Rental>? _baseRepository;


        public RentalService(IBaseRepository<Rental>? baseRepository, IUnitOfWork unitOfWork)          
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Rental entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("kiralama işlemi başarılı");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("silme işlemi başarılı");
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Rental>>(data ,"tüm kiralama işlemleri getirildi");
        }

        public IDataResult<Rental> GetById(Guid id)
        {
            var data = _baseRepository.Get(x => x.Id == id);
            return new SuccessDataResult<Rental>(data, " Kiralama başarı ile listelendi");
        }

        public async Task<IResult> Update(Rental entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("güncelleme işlemi başarılı");
        }
    }
}
