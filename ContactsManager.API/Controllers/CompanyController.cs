using ContactsManager.Core.Dtos;
using ContactsManager.Core.Entities;
using ContactsManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyRepository)
        {
            _companyService = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();

            if (!companies.Any())
            {
                return NotFound();
            }

            return companies;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            if (! await _companyService.CompanyExists(id))
            {
                return NotFound();
            }

            return await _companyService.GetCompanyById(id);
        }

        [HttpGet("addresses")]
        public async Task<ActionResult<List<CompanyAddress>>> GetCompany()
        {

            return await _companyService.GetAllAddresses();
        }

        [HttpPost]
        public async Task<ActionResult<CompanyForCreation>> CreateCompany(CompanyForCreation companyForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(!await _companyService.CreateCompany(companyForCreation))
            {
                return StatusCode(500, "A Problem happened while handling your request"); 
            }

            return Ok();
        }

        [HttpPost("{companyId}")]
        public async Task<ActionResult<CompanyAddressForCreation>> AddAddress(int companyId, CompanyAddressForCreation companyAddress)
        {
            if (! await _companyService.CompanyExists(companyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            companyAddress.CompanyId = companyId;

            if (!await _companyService.AddAddress(companyAddress))
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult<Company>> UpdateCompany(Company company)
        {
            if (!await _companyService.CompanyExists(company.Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(!await _companyService.UpdateCompany(company))
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPut("updateaddress")]
        public async Task<ActionResult<Company>> UpdateCompanyAddress(CompanyAddress companyAddress)
        {
            if (!await _companyService.CompanyExists(companyAddress.CompanyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _companyService.UpdateCompanyAddress(companyAddress))
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }
    }
}
