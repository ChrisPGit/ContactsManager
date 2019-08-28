using ContactsManager.API.Controllers;
using ContactsManager.API.Entities;
using ContactsManager.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ContactsManager.Tests
{
    public class CompanyControllerTest
    {
        private CompanyController _controller;
        private ICompanyRepository _repo;
        public CompanyControllerTest()
        {
            _repo = new CompanyRepositoryFake();
            _controller = new CompanyController(_repo);
        }

        [Fact]
        public void GetWhenCalledReturnsCompany()
        {
            var company = _controller.GetCompany(1);

            Assert.IsType<Task<ActionResult<Company>>>(company);
        }

        [Fact]
        public void GetAllWhenCalledReturnsListCompanies()
        {
            var companies = _controller.GetAllCompanies();

            Assert.IsType<Task<ActionResult<List<Company>>>>(companies);
        }

    }
}
