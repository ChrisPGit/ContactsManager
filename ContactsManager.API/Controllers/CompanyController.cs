using ContactsManager.API.Dtos;
using ContactsManager.API.Entities;
using ContactsManager.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();

            if (!companies.Any())
            {
                return NotFound();
            }

            return companies;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            if (! await _companyRepository.CompanyExists(id))
            {
                return NotFound();
            }

            return await _companyRepository.GetCompanyById(id);
        }

        [HttpGet("addresses")]
        public async Task<ActionResult<List<CompanyAddress>>> GetCompany()
        {

            return await _companyRepository.GetAllAddresses();
        }

        [HttpPost]
        public async Task<ActionResult<CompanyForCreation>> CreateCompany(CompanyForCreation companyForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var company = new Company
            {
                Name = companyForCreation.Name,
                ESite = companyForCreation.ESite,
                HomePhone = companyForCreation.HomePhone,
                VAT = companyForCreation.VAT
            };

            company.CompanyAddresses.Add(new CompanyAddress
            {
                CompanyAdressTypeId = CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress,
                Address = companyForCreation.PrincipalAddress,
                ZipCode = companyForCreation.ZipCode,
                City = companyForCreation.City,
                Country = companyForCreation.Country
            });

            await _companyRepository.CreateCompany(company);

            if(!await _companyRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request"); 
            }

            return Ok();
        }

        [HttpPost("{companyId}")]
        public async Task<ActionResult<CompanyAddress>> AddAddress(int companyId, CompanyAddress companyAddress)
        {
            if (! await _companyRepository.CompanyExists(companyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            companyAddress.CompanyId = companyId;

            await _companyRepository.AddAddress(companyAddress);

            if (! await _companyRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPut("update/{companyId}")]
        public async Task<ActionResult<Company>> UpdateCompany(int companyId, Company company)
        {
            if (! await _companyRepository.CompanyExists(companyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            company.Id = companyId;

            _companyRepository.UpdateCompany(company);

            if(!await _companyRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }

        [HttpPut("updateaddress/{companyAddressId}")]
        public async Task<ActionResult<Company>> UpdateCompanyAddress(int companyAddressId, CompanyAddress companyAddress)
        {
            if (!await _companyRepository.CompanyExists(companyAddress.CompanyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            companyAddress.Id = companyAddressId;

            _companyRepository.UpdateCompanyAddress(companyAddress);

            if (!await _companyRepository.Save())
            {
                return StatusCode(500, "A Problem happened while handling your request");
            }

            return Ok();
        }
    }
}
