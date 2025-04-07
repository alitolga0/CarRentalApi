using CarRentalApi.Core.Repository;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;

namespace CarRentalApi.Service.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IBaseRepository<Brand> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork, IBaseRepository<Brand> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }

        public async Task<IResult> Add(Brand entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Brand başarıyla eklendi");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Brand başarıyla silindi");
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Brand>>(data, "Başarıyla listelendi");
        }

        public IDataResult<Brand> GetById(Guid id)
        {
            var data = _baseRepository.Get(x => x.Id == id); 
            return new SuccessDataResult<Brand>(data, "Başarıyla listelendi");
        }

        public async Task<IResult> Update(Brand entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarıyla güncellendi");
        }
    }
}
