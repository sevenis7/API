using AspApplication.BLL.Interfaces;
using AspApplication.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AspApplication.BLL.Service
{

    public class ApiService : IContactService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApiService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            var token = _contextAccessor.HttpContext.Session.GetString("JWToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<bool> Create(Contact contact)
        {
            var url = _httpClient.BaseAddress;
            var response = await _httpClient.PostAsJsonAsync<Contact>(url, contact);
            if (response.IsSuccessStatusCode) return true;
            else return false;
        }

        public async Task<bool> Delete(int id)
        {
            var url = new Uri(_httpClient.BaseAddress.ToString() + $@"/{id}");
            var response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode) return true;
            else return false;
        }

        public async Task<bool> Edit(int id, Contact contact)
        {
            var url = new Uri(_httpClient.BaseAddress.ToString() + $@"/{id}");
            var response = await _httpClient.PutAsJsonAsync<Contact>(url, contact);
            if (response.IsSuccessStatusCode) return true;
            else return false;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var url = _httpClient.BaseAddress;
            var response = _httpClient.GetStringAsync(url).Result;
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(response);
            return contacts;
        }

        public async Task<Contact> GetContact(int id)
        {

            var url = new Uri(_httpClient.BaseAddress.ToString() + $@"/{id}");
            var response = await _httpClient.GetStringAsync(url);
            var contact = JsonConvert.DeserializeObject<Contact>(response);
            return contact;
        }
    }
}
