using ContactsManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.Interfaces
{
    public interface IContactService
    {
        Task<bool> CreateContact(Contact contact, int companyId);
        Task<bool> ContactExists(int contactId);
        Task<bool> CompanyExists(int companyId);
        Task<bool> ContactCompanyRelationExists(int contactId, int companyId);
        Task<bool> DeleteContact(Contact contact);
        Task<Contact> GetContactById(int contactId);
        Task<List<Contact>> GetAllContacts();
        Task<List<Contact>> GetContactsByCompanyId(int companyId);
        Task<bool> UpdateContact(Contact contact);
        Task<bool> AddContactToCompany(int contactId, int companyId);
    }
}
