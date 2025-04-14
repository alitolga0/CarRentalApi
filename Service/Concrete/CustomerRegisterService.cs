using CarRentalApi.Core.Repository;
using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Service.Concrete
{
    public class CustomerRegisterService : ICustomerRegisterService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Register> _baseRepository;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public CustomerRegisterService(UserManager<User> userManager, IUnitOfWork unitOfWork, IBaseRepository<Register> baseRepository, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
            _roleManager = roleManager;
        }
        public async Task<IResult> Add(Register model)
        {

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new ErrorResult("Kullanıcı oluşturulamadı.");
            }

            var roleExists = await _roleManager.RoleExistsAsync("Customer");
            if (!roleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole<Guid>("Customer"));
                if (!roleResult.Succeeded)
                {
                    return new ErrorResult("Rol oluşturulamadı.");
                }
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            return new SuccessResult("Kayıt başarılı.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarıyla silindi");
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
