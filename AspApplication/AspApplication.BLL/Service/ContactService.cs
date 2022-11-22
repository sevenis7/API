using AspApplication.BLL.Interfaces;
using AspApplication.DAL.Interfaces;
using AspApplication.Domain.Entity;

namespace AspApplication.BLL.Service
{
    public class ContactService : IContactService
    {
        private readonly IBaseRepository<Contact> _contactRepository;

        public ContactService(IBaseRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Create(Contact contact)
        {
            try
            {
                await _contactRepository.Create(contact);
                if (contact.Id > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var contacts = await _contactRepository.GetAll();
                var contact = contacts.FirstOrDefault(x => x.Id == id);
                if (contact == null)
                {
                    return false;
                }
                else
                {
                    await _contactRepository.Delete(contact);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _contactRepository.GetAll();
        }

        public async Task<bool> Edit(int id, Contact contact)
        {
            try
            {
                var contacts = await _contactRepository.GetAll();
                var editContact = contacts.FirstOrDefault(x => x.Id == id);
                if (contact == null || editContact == null)
                {
                    return false;
                }
                else
                {
                    editContact.LastName = contact.LastName;
                    editContact.FirstName = contact.FirstName;
                    editContact.MiddleName = contact.MiddleName;
                    editContact.PhoneNumber = contact.PhoneNumber;
                    editContact.Addres = contact.Addres;
                    editContact.Description = contact.Description;
                    await _contactRepository.Update(editContact);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Contact> GetContact(int id)
        {
            var contact = _contactRepository.GetAll().Result.FirstOrDefault(x => x.Id == id);
            if (contact == null) return new NullContact();
            else return contact;
        }

    }
}
