using AspApplication.BLL.Interfaces;
using AspApplication.DAL.Interfaces;
using AspApplication.Domain.Entity;
using AspApplication.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AspApplication.BLL.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IJWT _jwt;
        private User _user;

        public AccountService(IBaseRepository<User> userRepository, IJWT jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }

        public async Task<string> Login(UserLogin model)
        {
            try
            {
                var user = _userRepository.GetAll().Result.FirstOrDefault(x => x.UserName == model.UserName);
                if (user == null)
                {
                    return "";
                }

                if (!VerifyHash(model.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return "";
                }

                _user = user;
                string token = _jwt.GetToken(user);
                return token;

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<bool> Register(UserRegistration model)
        {
            try
            {
                var user = _userRepository.GetAll().Result.FirstOrDefault(x => x.UserName == model.UserName);
                if (user != null)
                {
                    return false;
                }

                CreateHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

                Role userRole;
                Enum.TryParse(model.Role, out userRole);

                user = new User()
                {
                    UserName = model.UserName,
                    Role = userRole,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                await _userRepository.Create(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var all = _userRepository.GetAll().Result;
            var users = all.Where(x => x.Role == Role.User);
            return users;
        }

        public async Task<bool> Delete(string userName)
        {
            try
            {
                var users = await _userRepository.GetAll();
                var user = users.FirstOrDefault(x => x.UserName == userName);
                if (user == null) return false;
                else
                {
                    await _userRepository.Delete(user);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        private bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public Task<User> GetMe()
        {
            throw new NotImplementedException();
        }
    }

}
