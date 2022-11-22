using AspApplication.Domain.Entity;

namespace AspApplication.BLL.Interfaces
{
    public interface IContactService
    {
        Task<Contact> GetContact(int id);

        Task<bool> Create(Contact contact);

        Task<bool> Delete(int id);

        Task<IEnumerable<Contact>> GetAll();

        Task<bool> Edit(int id, Contact contact);

    }
}
