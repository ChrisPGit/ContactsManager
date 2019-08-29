using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.API.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private ContactsManagerContext _context;

        public CompanyRepository(ContactsManagerContext context)
        {
            _context = context;
        }

        public async Task AddAddress(Data.CompanyAddress companyAddress)
        {
            CheckAndMovePrincipalAddress(companyAddress);
            await _context.CompanyAddresses.AddAsync(companyAddress);
        }

        public async Task<bool> CompanyExists(int companyId)
        {
            return await _context.Companies.AnyAsync(c => c.Id == companyId);
        }

        public async Task CreateCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<List<CompanyAddress>> GetAllAddresses()
        {
            return await _context.CompanyAddresses.ToListAsync();
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
        }

        public void UpdateCompanyAddress(CompanyAddress companyAddress)
        {
            CheckAndMovePrincipalAddress(companyAddress);
            _context.CompanyAddresses.Update(companyAddress);
        }

        private void CheckAndMovePrincipalAddress(CompanyAddress companyAddress)
        {
            var company = _context.Companies.Find(companyAddress.CompanyId);
            var companyAddresses = _context.CompanyAddresses.Where(ca => ca.CompanyId == company.Id);

            if (companyAddress.CompanyAdressTypeId == CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress
                && companyAddresses.Any(c => c.CompanyAdressTypeId == CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress))
            {
                var oldPrincipalAddress = companyAddresses
                    .First(c => c.CompanyAdressTypeId == CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress);
                oldPrincipalAddress.CompanyAdressTypeId = CompanyAddressTypePartial.CompanyAddressTypeEnum.Agency;

                _context.CompanyAddresses.Update(oldPrincipalAddress);
            }
        }
    }
}
