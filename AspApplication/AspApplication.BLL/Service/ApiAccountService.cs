using AspApplication.BLL.Interfaces;
using AspApplication.Domain.ViewModels;
using AspApplication.Domain.Entity;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AspApplication.BLL.Service
{
    public class ApiAccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApiAccountService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            var token = _contextAccessor.HttpContext.Session.GetString("JWToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<bool> Delete(string userName)
        {
            var url = _httpClient.BaseAddress + $@"/user/{userName}";
            var response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode) return true;
            else return false;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var url = _httpClient.BaseAddress + $@"/user";
            var response = _httpClient.GetStringAsync(url).Result;
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(response);
            return users;
        }

        public async Task<string> Login(UserLogin model)
        {
            var url = _httpClient.BaseAddress + @"/account/login";
            var response = await _httpClient.PostAsJsonAsync<UserLogin>(url, model);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                _contextAccessor.HttpContext.Session.SetString("JWToken", token);
                _contextAccessor.HttpContext.Session.SetString("UserName", model.UserName);
                var jwt = new JwtSecurityToken(token);
                var role = jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                _contextAccessor.HttpContext.Session.SetString("Role", role);
                return token;
            }
            return "";
        }

        public async Task<bool> Register(UserRegistration model)
        {
            var url = _httpClient.BaseAddress + @"/account/register";
            var response = await _httpClient.PostAsJsonAsync<UserRegistration>(url, model);
            return true;
        }
    }
}
