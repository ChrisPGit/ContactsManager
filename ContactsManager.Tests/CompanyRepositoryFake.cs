using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContactsManager.Data;
using ContactsManager.API.Services;

namespace ContactsManager.Tests
{
    public class CompanyRepositoryFake : ICompanyRepository
    {
        public Task AddAddress(CompanyAddress companyAddress)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompanyExists(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyAddress>> GetAllAddresses()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return new List<Company>()
            {
                new Company
                {
                    Id = 1,
                    Name = "Test",
                    Vat = "TestVat",
                },
                 new Company
                {
                    Id = 2,
                    Name = "Test2",
                    Vat = "TestVat2",
                },


            };
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            return new Company()
            {
                Id = 1,
                Name = "Test",
                Vat = "TestVat",
            };
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompanyAddress(CompanyAddress companyAddress)
        {
            throw new NotImplementedException();
        }
    }
}
