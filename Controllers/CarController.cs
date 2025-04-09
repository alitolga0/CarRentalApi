using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Car>> GetAll()
        {
            return _carService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Car> GetById(Guid id)
        {
            return _carService.GetById(id);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> Add(Car entity)
        {
            return await _carService.Add(entity);
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _carService.Delete(id);
        }
        [HttpPost("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> Update(Car entity)
        {
            return await _carService.Update(entity);
        }
    }
}
