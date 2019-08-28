using ContactsManager.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsManager.API.Services
{
    public interface IContactRepository
    {
        Task CreateContact(Contact contact);
        Task<bool> ContactExists(int contactId);
        Task DeleteContact(int contcatId);
        Task<Contact> GetContactById(int contcatId);
        Task<List<Contact>> GetAllContacts();
        Task<List<Contact>> GetContactsByCompanyId(int companyId);
        void UpdateContact(Contact contact);
        Task AddContactToCompany(Contact contact, int companyId);
    }
}
