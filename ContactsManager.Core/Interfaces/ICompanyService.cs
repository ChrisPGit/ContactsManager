using ContactsManager.Core.Dtos;
using ContactsManager.Core.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> CreateCompany(CompanyForCreation companyDto);
        Task<bool> CompanyExists(int companyId);
        Task<bool> AddAddress(CompanyAddressForCreation companyAddressDto);
        Task<Company> GetCompanyById(int companyId);
        Task<List<Company>> GetAllCompanies();
        Task<bool> UpdateCompany(Company company);
        Task<bool> UpdateCompanyAddress(CompanyAddress companyAddress);
        Task<List<CompanyAddress>> GetAllAddresses();
    }
}
