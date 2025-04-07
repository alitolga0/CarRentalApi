using CarRentalApi.Core.Repository;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;

namespace CarRentalApi.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Category> _baseRepository;
        public CategoryService(IUnitOfWork unitOfWork, IBaseRepository<Category> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }

        public async Task<IResult> Add(Category entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("kategori başarıyla eklendi");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("kategori başarıyla silindi");
            
        }

        public IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Category>>(data," kategoriler başarı ile listelendi");

        }

        public IDataResult<Category> GetById(Guid id)
        {
            var data = _baseRepository.Get(x => x.Id==id);
            return new SuccessDataResult<Category>(data, " kategori başarı ile listelendi");
        }

        public async Task<IResult> Update(Category entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarı ile güncellendi");
        }
    }
}
