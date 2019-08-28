using ContactsManager.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsManager.API.Services
{
    public interface IContactRepository
    {
        Task CreateContact(Contact contact);
        Task<bool> ContactExists(int contactId);
        Task<bool> ContactCompanyRelationExists(int contactId, int companyId);
        void DeleteContact(Contact contact);
        Task<Contact> GetContactById(int contactId);
        Task<List<Contact>> GetAllContacts();
        Task<List<Contact>> GetContactsByCompanyId(int companyId);
        void UpdateContact(Contact contact);
        Task AddContactToCompany(int contactId, int companyId);
        Task<bool> Save();
    }
}
