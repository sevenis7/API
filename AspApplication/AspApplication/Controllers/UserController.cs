using AspApplication.BLL.Interfaces;
using AspApplication.BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AspApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _accountService.GetAllUsers());
        }

        public async Task<IActionResult> Delete(string userName)
        {
            await _accountService.Delete(userName);
            return RedirectToAction("Index", "Values");
        }

    }
}
