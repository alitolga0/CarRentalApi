using CarRentalApi.Core.Repository;
using CarRentalApi.Core.Service;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;

namespace CarRentalApi.Service.Concrete
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Car> _baseRepository;

        public CarService(IBaseRepository<Car> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Car entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Araba başarıyla eklendi");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Araba başarıyla silindi");
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Car>>(data, "Arabalar başarıyla listelendi");
        }

        public IDataResult<Car> GetById(Guid id)
        {
            var data = _baseRepository.Get(x => x.Id == id);
            return new SuccessDataResult<Car>(data, " kategori başarı ile listelendi");
        }

        public async Task<IResult> Update(Car entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarıyla güncellendi");
        }

    }
}
