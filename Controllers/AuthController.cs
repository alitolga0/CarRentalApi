using CarRentalApi.Core.Utilities.Results;
using CarRentalApi.Models;
using CarRentalApi.Models.RequestModel;
using CarRentalApi.Service.Abstract;
using CarRentalApi.Service.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerRegisterService _customerRegisterService;
        private readonly ISellerRegisterService _sellerRegisterService;
        private readonly IAuthService _authService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AuthController(
            SignInManager<User> signInManager,
            UserManager<User> userManager, 
            IAuthService authService,
            ICustomerRegisterService customerRegisterService,
            ISellerRegisterService sellerRegisterService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authService = authService;
            _customerRegisterService = customerRegisterService;
            _sellerRegisterService = sellerRegisterService;
        }

        [HttpPost("register/customer")]
        public async Task<IActionResult> CustomerRegister([FromBody] Register register)
        {
            var result = await _customerRegisterService.Add(register);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register/seller")]
        public async Task<IActionResult> sellerRegister([FromBody] Register register)
        {
            var result = await _sellerRegisterService.Add(register);

            if (result.Success)
            {
                return Ok(result.Message);
            }

             return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
           
            if (user == null)
                return Unauthorized("Kullanıcı bulunamadı");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
                return Unauthorized("Şifre hatalı");

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}
