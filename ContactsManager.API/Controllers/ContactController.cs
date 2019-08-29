using ContactsManager.Data;
using ContactsManager.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private IContactRepository _contactRepository;
        private ICompanyRepository _companyRepository;
        public ContactController(IContactRepository contactRepository, ICompanyRepository companyRepository)
        {
            _contactRepository = contactRepository;
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();

            if (!contacts.Any())
            {
                return NotFound();
            }

            return contacts;
        }

        [HttpGet("bycompany/{companyId}")]
        public async Task<ActionResult<List<Contact>>> GetContactsByCompany(int companyId)
        {
            var contacts = await _contactRepository.GetAllContacts();

            if (!contacts.Any())
            {
                return NotFound();
            }

            return await _contactRepository.GetContactsByCompanyId(companyId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            if (!await _contactRepository.ContactExists(id))
            {
                return NotFound();
            }

            return await _contactRepository.GetContactById(id);
        }

        [HttpPost("{companyId}")]
        public async Task<ActionResult<Contact>> CreateContact(int companyId, Contact contact)
        {
            if (! await _companyRepository.CompanyExists(companyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _contactRepository.CreateContact(contact);

            if (! await _contactRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            await _contactRepository.AddContactToCompany(contact.Id, companyId);

            if (!await _contactRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPost("{companyId}/relation/{contactId}")]
        public async Task<ActionResult> AddToCompany(int contactId, int companyId)
        {
            if (! await _companyRepository.CompanyExists(companyId) 
                || ! await _contactRepository.ContactExists(contactId))
            {
                return NotFound();
            }

            if(await _contactRepository.ContactCompanyRelationExists(contactId, companyId))
            {
                return BadRequest();
            }

            await _contactRepository.AddContactToCompany(contactId, companyId);

            if (!await _contactRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPut("{contactId}")]
        public async Task<ActionResult<Contact>> UpdateContact(int contactId, Contact contact)
        {
            if (!await _contactRepository.ContactExists(contactId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            contact.Id = contactId;

            _contactRepository.UpdateContact(contact);

            if (!await _contactRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpDelete("{contactId}")]
        public async Task<ActionResult> DeleteContact(int contactId)
        {
            if (! await _contactRepository.ContactExists(contactId))
            {
                return NotFound();
            }

            var contact = await _contactRepository.GetContactById(contactId);

            _contactRepository.DeleteContact(contact);

            if (! await _contactRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

    }
}
