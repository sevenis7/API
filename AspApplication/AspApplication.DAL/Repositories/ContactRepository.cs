using AspApplication.DAL.DataContext;
using AspApplication.DAL.Interfaces;
using AspApplication.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspApplication.DAL.Repositories
{
    public class ContactRepository : IBaseRepository<Contact>
    {
        private readonly AspApplicationDbContext _db;

        public ContactRepository(AspApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Contact entity)
        {
            await _db.Contacts.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _db.Contacts.ToListAsync();
        }

        public async Task Delete(Contact entity)
        {
            _db.Contacts.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Contact entity)
        {
            _db.Contacts.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
