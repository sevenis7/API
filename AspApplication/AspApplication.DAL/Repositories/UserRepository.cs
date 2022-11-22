using AspApplication.DAL.DataContext;
using AspApplication.DAL.Interfaces;
using AspApplication.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspApplication.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AspApplicationDbContext _db;

        public UserRepository(AspApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task Update(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
