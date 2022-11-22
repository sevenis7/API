using AspApplication.BLL.Interfaces;
using AspApplication.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AspApplication.Controllers
{
    public class ValuesController : Controller
    {
        private readonly IContactService _contactService;
        private readonly HttpClient _httpClient;

        public ValuesController(IContactService contactService, HttpClient httpClient)
        {
            _contactService = contactService;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAll());
        }

        public async Task<IActionResult> Contact(int id)
        {
            return View(await _contactService.GetContact(id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            //if (String.IsNullOrWhiteSpace(HttpContext.Session.GetString("JWToken")))
            //{
            //    return RedirectToAction("index", "values");
            //}
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Contact contact)
        {
            await _contactService.Create(contact);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _contactService.GetContact(id);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] Contact contact)
        {
            await _contactService.Edit(id, contact);
            return RedirectToAction("Index");
        }

    }
}
