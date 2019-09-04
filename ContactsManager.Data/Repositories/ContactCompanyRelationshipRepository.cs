using ContactsManager.Core.Entities;
using ContactsManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Data.Repositories
{
    public class ContactCompanyRelationshipRepository : IContactCompanyRelationshipRepository
    {
        private ContactsManagerContext _context;
        public ContactCompanyRelationshipRepository(ContactsManagerContext context)
        {
            _context = context;
        }

        public async Task Create(ContactCompanyRelationship contactCompanyRelationship)
        {
            await _context.ContactCompanyRelationships.AddAsync(contactCompanyRelationship);
        }

        public void Delete(ContactCompanyRelationship contactCompanyRelationship)
        {
             _context.ContactCompanyRelationships.Remove(contactCompanyRelationship);
        }

        public IEnumerable<ContactCompanyRelationship> List()
        {
            return _context.ContactCompanyRelationships.AsEnumerable();
        }

        public IEnumerable<ContactCompanyRelationship> List(Expression<Func<ContactCompanyRelationship, bool>> predicate)
        {
            return _context.ContactCompanyRelationships
                .Where(predicate)
                .AsEnumerable();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

    }
}
