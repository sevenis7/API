using AspApplication.BLL.Interfaces;
using AspApplication.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace AspApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly HttpClient _httpClient;
        

        public AccountController(IAccountService accountService, HttpClient httpClient)
        {
            _accountService = accountService;
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!String.IsNullOrWhiteSpace(HttpContext.Session.GetString("JWToken")))
            {
                return RedirectToAction("Index", "Values");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] UserLogin model)
        {
            string token = await _accountService.Login(model);
            return RedirectToAction("Index", "Values");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] UserRegistration model)
        {
            await _accountService.Register(model);
            return RedirectToAction("Index", "Values");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Values");
        }
    }
}
