using AspApplication.BLL.Interfaces;
using AspApplication.Domain.Entity;
using AspApplication.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiContacts.Controllers
{
    [ApiController]
    [Authorize(Roles = nameof(Role.Admin))]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _accountService.GetAllUsers();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRegistration model)
        {
            if (_accountService.Register(model).Result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            if (_accountService.Delete(userName).Result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
