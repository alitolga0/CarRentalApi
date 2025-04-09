using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using CarRentalApi.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Rental>> GetAll()
        {
            return _rentalService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Rental> GetById(Guid id)
        {
            return _rentalService.GetById(id);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "User")]
        public async Task<IResult> Add(Rental entity)
        {
            return await _rentalService.Add(entity);
        }

        [HttpPost("Update")]
        [Authorize(Roles = "User")]
        public async Task<IResult> Update(Rental entity)
        {
            return await _rentalService.Update(entity);
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "User")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _rentalService.Delete(id);
        }
    }
}
