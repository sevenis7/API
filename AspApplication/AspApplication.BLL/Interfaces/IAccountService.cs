using AspApplication.Domain.Entity;
using AspApplication.Domain.ViewModels;

namespace AspApplication.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Register(UserRegistration model);

        Task<string> Login(UserLogin model);

        Task<bool> Delete(string userName);

        Task<IEnumerable<User>> GetAllUsers();

    }
}
