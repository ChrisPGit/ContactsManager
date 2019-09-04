using ContactsManager.API.Controllers;
using ContactsManager.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ContactsManager.Core.Interfaces;
using ContactsManager.Core.Entities;

namespace ContactsManager.Tests
{
    public class CompanyControllerTest
    {
        private CompanyController _controller;
        private ICompanyService _service;
        public CompanyControllerTest()
        {
            _service = new CompanyServiceFake();
            _controller = new CompanyController(_service);
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
            string test = string.Empty;

            Assert.IsType<Task<ActionResult<List<Company>>>>(companies);
        }

    }
}
