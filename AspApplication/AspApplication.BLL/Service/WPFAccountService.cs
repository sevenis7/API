using AspApplication.BLL.Interfaces;
using AspApplication.Domain.Entity;
using AspApplication.Domain.ViewModels;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Net.Http.Headers;

namespace AspApplication.BLL.Service
{
    public class WPFAccountService : IAccountService
    {
        string uri;
        string token;

        public WPFAccountService()
        {
            uri = @"https://localhost:7111/api/";
            token = "";
        }

        public async Task<bool> Delete(string userName)
        {
            var url = uri + @$"user/{userName}";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var url = uri + @"user";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = client.GetStringAsync(url).Result;
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(response);
                return users;
            }
        }

        public async Task<string> Login(UserLogin model)
        {
            var url = uri + @"account/login";
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync<UserLogin>(url, model).Result;
                if (response.IsSuccessStatusCode)
                {
                    token = await response.Content.ReadAsStringAsync();
                    return token;
                }
                return "";
            }
        }

        public async Task<bool> Register(UserRegistration model)
        {
            var url = uri + @"account/register";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync<UserRegistration>(url, model);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }
    }
}
