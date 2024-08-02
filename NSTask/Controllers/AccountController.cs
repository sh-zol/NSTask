using Domain.Core.User.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSTask.VMs;

namespace NSTask.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAppUserAppService _appuser;

        public AccountController(IAppUserAppService appuser)
        {
            _appuser = appuser;
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var result = await _appuser.Register(registerVM.Email,
                registerVM.Password,
                registerVM.Name,
                registerVM.PhoneNumber,
                registerVM.IsAdmin,
                registerVM.IsManufacturer);
            if(result.Count == 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return Ok(); 
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var result = await _appuser.Login(login.Email, login.Password);
            if(result == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("LogOut")]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _appuser.SignOut();
            return Ok();
        }
    }
}
