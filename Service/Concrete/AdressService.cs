using CarRentalApi.Core.Repository;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Service.Concrete
{
    public class AdressService : IAdressSerice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Adress> _baseRepository;

        public AdressService(IBaseRepository<Adress> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Adress entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Adress Başarıyla eklendi");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Adress başarıyla silindi");
        }

        public IDataResult<List<Adress>> GetAll(Expression<Func<Adress, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Adress>>(data,"Adresler başarıyla listelendi");
        }

        public IDataResult<Adress> GetById(Guid id)
        {
            var data = _baseRepository.Get(x=>x.Id==id);
            return new SuccessDataResult<Adress>(data,"Adres başarıyla getirildi");
        }

        public async Task<IResult> Update(Adress entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Adres başarıyla güncellendi");
        }
    }
}
