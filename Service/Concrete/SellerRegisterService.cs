using CarRentalApi.Core.Repository;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using System.Linq.Expressions;
using CarRentalApi.Core.Repository;
using Microsoft.AspNetCore.Identity;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Service.Concrete
{
    public class SellerRegisterService : ISellerRegisterService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Register> _baseRepository;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
       
        public SellerRegisterService(UserManager<User> userManager, IUnitOfWork unitOfWork, IBaseRepository<Register> baseRepository, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
            _roleManager = roleManager;
        }

        public async Task<IResult> Add(Register entity)
        {
            var user = new User
            {
                UserName = entity.UserName,
                Email = entity.Email
            };

            var result = await _userManager.CreateAsync(user, entity.Password);
            if (!result.Succeeded)
            {
                return new ErrorResult("Kullanıcı oluşturulamadı.");
            }

            var roleExists = await _roleManager.RoleExistsAsync("Seller");
            if (!roleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole<Guid>("Seller"));
                if (!roleResult.Succeeded)
                {
                    return new ErrorResult("Rol oluşturulamadı.");
                }
            }

            await _userManager.AddToRoleAsync(user, "Seller");

            return new SuccessResult("Kayıt başarılı.");
        }


        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarı ile silindi");
        }
        public async Task<IResult> Update(Register entity)
        {
           await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarıyla güncellendi");
        }

        public IDataResult<List<Register>> GetAll(Expression<Func<Register, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Register> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
