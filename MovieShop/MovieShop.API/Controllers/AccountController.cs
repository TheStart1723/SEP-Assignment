using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var user = await _accountService.ValidateUser(model);
            if (user == null)
            {
                return Unauthorized("Wrong email/password");
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAccountDetailsById(int id)
        {
            var user = await _userService.GetUserDetails(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccount();
            if(!accounts.Any()) return NotFound();
            return Ok(accounts);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model)
        {
            var id = await _accountService.RegisterUser(model);
            if (id == -1) return Conflict();
            return Created("/api/Account/{id}",id);
        }
    }
}
