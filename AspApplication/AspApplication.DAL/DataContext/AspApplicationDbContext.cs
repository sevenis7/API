using AspApplication.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspApplication.DAL.DataContext
{
    public class AspApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Contact> Contacts { get; set; }

        public override DbSet<User> Users { get; set; }

        public AspApplicationDbContext(DbContextOptions<AspApplicationDbContext> options) : base(options) 
        {
        }

    }
}
