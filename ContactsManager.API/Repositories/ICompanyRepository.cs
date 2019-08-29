using ContactsManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.API.Services
{
    public interface ICompanyRepository
    {
        Task CreateCompany(Company company);
        Task<bool> CompanyExists(int companyId);
        Task AddAddress(CompanyAddress companyAddress);
        Task<Company> GetCompanyById(int companyId);
        Task<bool> Save();
        Task<List<Company>> GetAllCompanies();
        void UpdateCompany(Company company);
        void UpdateCompanyAddress(CompanyAddress companyAddress);
        Task<List<CompanyAddress>> GetAllAddresses();
    }
}
