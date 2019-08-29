using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;


namespace ContactsManager.API.Services
{
    public class ContactRepository : IContactRepository
    {
        private ContactsManagerContext _context;
        public ContactRepository(ContactsManagerContext context)
        {
            _context = context;
        }

        public async Task AddContactToCompany(int contactId, int companyId)
        {
            await _context.ContactCompanyRelationships.AddAsync(new ContactCompanyRelationship
            {
                ContactId = contactId,
                CompanyId = companyId
            });
        }

        public async Task<bool> ContactCompanyRelationExists(int contactId, int companyId)
        {
            return await _context.ContactCompanyRelationships
                .AnyAsync(ccr => ccr.ContactId == contactId && ccr.CompanyId == companyId);
        }

        public async Task<bool> ContactExists(int contactId)
        {
            return await _context.Contacts.AnyAsync(c => c.Id == contactId);
        }

        public async Task CreateContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _context.ContactCompanyRelationships.RemoveRange
                (
                    _context.ContactCompanyRelationships.Where(ccr => ccr.ContactId == contact.Id)
                );
            _context.Contacts.Remove(contact);
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            return await _context.Contacts.FindAsync(contactId);
        }

        public async Task<List<Contact>> GetContactsByCompanyId(int companyId)
        {
            var contactsIds = await _context.ContactCompanyRelationships
                .Where(c => c.CompanyId == companyId)
                .Select(c => c.ContactId).ToListAsync();
            return await _context.Contacts
                .Where(c => contactsIds.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
        }
    }
}
