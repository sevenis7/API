using AspApplication.BLL.Interfaces;
using AspApplication.Domain.Entity;
using AspApplication.Domain.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiContacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistration model)
        {
            if (_accountService.Register(model).Result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {

            string token = await _accountService.Login(model);
            if (String.IsNullOrWhiteSpace(token))
            {
                return BadRequest("there is no token");
            }
            return Ok(token);
        }

        [HttpGet("getme")]
        [Authorize]
        public async Task<string> GetMe()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return $"Пользователь: {user}\n" +
                $"Роль: {role}";
        }
    }
}
