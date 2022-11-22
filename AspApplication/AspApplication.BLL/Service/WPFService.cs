using AspApplication.BLL.Interfaces;
using AspApplication.Domain.Entity;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace AspApplication.BLL.Service
{
    public class WPFService : IContactService
    {
        private string uri;
        private string _token;

        public WPFService(string token)
        {
            _token = token;
            uri = @"https://localhost:7111/api/values/";
        }

        public async Task<bool> Create(Contact contact)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                var response = await client.PostAsJsonAsync<Contact>(uri, contact);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                var url = uri + $"{id}";
                var response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }

        public async Task<bool> Edit(int id, Contact contact)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                var url = uri + $"{id}";
                var response = await client.PutAsJsonAsync<Contact>(url, contact);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(uri).Result;
                var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(response);
                return contacts;
            }
        }

        public async Task<Contact> GetContact(int id)
        {
            using (var client = new HttpClient())
            {
                var url = uri + $"{id}";
                var response = await client.GetStringAsync(url);
                var contact = JsonConvert.DeserializeObject<Contact>(response);
                return contact;
            }

        }
    }
}
