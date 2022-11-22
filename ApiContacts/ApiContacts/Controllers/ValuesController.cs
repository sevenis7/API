using AspApplication.BLL.Interfaces;
using AspApplication.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiContacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IContactService _contactService;

        public ValuesController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _contactService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactService.GetContact(id);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<bool> Create([FromBody] Contact contact)
        {
            return await _contactService.Create(contact);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<bool> Delete(int id)
        {
            return await _contactService.Delete(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<bool> Edit(int id, [FromBody] Contact contact)
        {
            return await _contactService.Edit(id, contact);
        }

    }
}
