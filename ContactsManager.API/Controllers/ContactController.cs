using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsManager.Core.Entities;
using ContactsManager.Core.Interfaces;

namespace ContactsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContacts();

            if (!contacts.Any())
            {
                return NotFound();
            }

            return contacts;
        }

        [HttpGet("bycompany/{companyId}")]
        public async Task<ActionResult<List<Contact>>> GetContactsByCompany(int companyId)
        {
            var contacts = await _contactService.GetAllContacts();

            if (!contacts.Any())
            {
                return NotFound();
            }

            return await _contactService.GetContactsByCompanyId(companyId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            if (!await _contactService.ContactExists(id))
            {
                return NotFound();
            }

            return await _contactService.GetContactById(id);
        }

        [HttpPost("{companyId}")]
        public async Task<ActionResult<Contact>> CreateContact(int companyId, Contact contact)
        {
            if (! await _contactService.CompanyExists(companyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (! await _contactService.CreateContact(contact, companyId))
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPost("{companyId}/relation/{contactId}")]
        public async Task<ActionResult> AddToCompany(int contactId, int companyId)
        {
            if (! await _contactService.CompanyExists(companyId) 
                || ! await _contactService.ContactExists(contactId))
            {
                return NotFound();
            }

            if(await _contactService.ContactCompanyRelationExists(contactId, companyId))
            {
                return BadRequest();
            }

            if (!await _contactService.AddContactToCompany(contactId, companyId))
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> UpdateContact(Contact contact)
        {
            if (!await _contactService.ContactExists(contact.Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _contactService.UpdateContact(contact))
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpDelete("{contactId}")]
        public async Task<ActionResult> DeleteContact(int contactId)
        {
            if (! await _contactService.ContactExists(contactId))
            {
                return NotFound();
            }

            var contact = await _contactService.GetContactById(contactId);

            if (! await _contactService.DeleteContact(contact))
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }
    }
}
