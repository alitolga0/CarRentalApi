using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using CarRentalApi.Service.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Brand>> GetAll()
        {
            return _brandService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Brand> GetById(Guid id)
        {
            return _brandService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(Brand entity)
        {
            return await _brandService.Add(entity);
        }
        [HttpPost("Update")]
        public async Task<IResult> Update(Brand entity)
        {
            return await _brandService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _brandService.Delete(id);
        }
    }
}
