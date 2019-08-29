using ContactsManager.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Tests
{
    public interface ICompanyRepositoryFake
    {
        Task<Company> GetCompanyById(int companyId);
        Task<List<Company>> GetAllCompanies();
    }
}
