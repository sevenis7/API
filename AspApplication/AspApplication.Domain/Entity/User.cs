using Microsoft.AspNetCore.Identity;

namespace AspApplication.Domain.Entity
{
    public class User : IdentityUser
    {
        public string UserName { get; set; }

        public Role Role { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
