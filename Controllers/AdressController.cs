using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Service.Abstract;
using CarRentalApi.Service.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using IResult = CarRentalApi.Core.Utilities.Results.IResult;
namespace CarRentalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly IAdressSerice _adressSerice;

        public AdressController(IAdressSerice adressSerice)
        {
            _adressSerice = adressSerice;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Adress>> GetAll()
        {
            return _adressSerice.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Adress> GetById(Guid id)
        {
            return _adressSerice.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(Adress entity)
        {
            return await _adressSerice.Add(entity);
        }
        [HttpPost("Update")]
        public async Task<IResult> Update(Adress entity)
        {
            return await _adressSerice.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _adressSerice.Delete(id);
        }
    }
}
