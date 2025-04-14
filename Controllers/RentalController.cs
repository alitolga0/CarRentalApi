using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using CarRentalApi.Service.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("GetAll")]
        [Authorize]
        public IDataResult<List<Rental>> GetAll()
        {
            return _rentalService.GetAll();
        }

        [HttpGet("GetById")]
        [Authorize]
        public IDataResult<Rental> GetById(Guid id)
        {
            return _rentalService.GetById(id);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Customer")]
        public async Task<IResult> Add(Rental entity)
        {
            return await _rentalService.Add(entity);
        }

        [HttpPost("Update")]
        [Authorize(Roles = "Customer")]
        public async Task<IResult> Update(Rental entity)
        {
            return await _rentalService.Update(entity);
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "Customer")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _rentalService.Delete(id);
        }

        [HttpGet("GetAllBeforeNow")]
        [Authorize(Roles = "Customer")]
        public IDataResult<List<Rental>> GetAllBeforeNow()
        {
            return _rentalService.GetAllBeforeNow();
        }
    }
}
