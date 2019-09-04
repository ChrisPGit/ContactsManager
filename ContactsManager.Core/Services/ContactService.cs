using ContactsManager.Core.Entities;
using ContactsManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Core.Services
{
    public class ContactService : IContactService
    {
        private IRepository<Contact> _repository;
        private IContactCompanyRelationshipRepository _repoRelationship;
        private ICompanyService _companyService;
        public ContactService(IRepository<Contact> repository,
            IContactCompanyRelationshipRepository repoRelationship,
            ICompanyService companyService)
        {
            _repository = repository;
            _repoRelationship = repoRelationship;
            _companyService = companyService;
        }

        public async Task<bool> AddContactToCompany(int contactId, int companyId)
        {

            if (!await ContactCompanyRelationExists(contactId, companyId))
            {
                await _repoRelationship.Create(new ContactCompanyRelationship
                {
                    CompanyId = companyId,
                    ContactId = contactId
                });
            }

            return await _repoRelationship.Save();
        }

        public async Task<bool> ContactCompanyRelationExists(int contactId, int companyId)
        {
            if (!await _companyService.CompanyExists(companyId) || !await ContactExists(contactId))
            {
                return false;
            }

            return _repoRelationship.List(r => r.CompanyId == companyId)
                .Any(r => r.ContactId == contactId);
        }

        public async Task<bool> ContactExists(int contactId)
        {
            return await _repository.Get(contactId) != null;
        }

        public async Task<bool> CompanyExists(int companyId)
        {
            return await _companyService.CompanyExists(companyId);
        }


        public async Task<bool> CreateContact(Contact contact, int companyId)
        {
            if (!await _companyService.CompanyExists(companyId))
            {
                return false;
            }

            await _repository.Create(contact);

            if (!await _repository.Save()) return false;

            await AddContactToCompany(contact.Id, companyId);

            return await _repository.Save();
        }

        public async Task<bool> DeleteContact(Contact contact)
        {
            var relations = _repoRelationship.List(r => r.ContactId == contact.Id).ToList();
            foreach (var relation in relations)
            {
                _repoRelationship.Delete(relation);
            }

            return await _repoRelationship.Save();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _repository.List().ToListAsync();
        }

        public Task<Contact> GetContactById(int contactId)
        {
            return _repository.Get(contactId);
        }

        public async Task<List<Contact>> GetContactsByCompanyId(int companyId)
        {
            if (!await _companyService.CompanyExists(companyId))
            {
                return null;
            }

            var companyContactsIds = _repoRelationship.List(r => r.CompanyId == companyId)
                .Select(r => r.ContactId).ToList();
            return await _repository.List(c => companyContactsIds.Contains(c.Id)).ToListAsync();
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            _repository.Update(contact);
            return await _repository.Save();
        }
    }
}
