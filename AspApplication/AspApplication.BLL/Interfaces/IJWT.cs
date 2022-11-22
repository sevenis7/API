using AspApplication.Domain.Entity;

namespace AspApplication.BLL.Interfaces
{
    public interface IJWT
    {
        public string GetToken(User user);
        string Validate (string token);
    }
}
