using ContactsManager.Core.Dtos;
using ContactsManager.Core.Entities;
using ContactsManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private IRepository<Company> _repository;
        private IRepository<CompanyAddress> _repoAddress;
        public CompanyService(IRepository<Company> repository, IRepository<CompanyAddress> repositoryAddress)
        {
            _repository = repository;
            _repoAddress = repositoryAddress;
        }

        public async Task<bool> AddAddress(CompanyAddressForCreation companyAddressdto)
        {
            if (!await CompanyExists(companyAddressdto.CompanyId))
            {
                return false;
            }
            CheckAndMovePrincipalAddress(companyAddressdto);
            var company = await _repository.Get(companyAddressdto.CompanyId);

            // TODO AutoMapping
            company.CompanyAddresses.Add(new CompanyAddress
            {
                Address = companyAddressdto.Address,
                City = companyAddressdto.City,
                ZipCode = companyAddressdto.ZipCode,
                Country = companyAddressdto.Country,
                CompanyAdressTypeId = companyAddressdto.CompanyAdressTypeId,
            });

            return await _repository.Save();
        }

        public async Task<bool> CompanyExists(int companyId)
        {
            return await _repository.Get(companyId) != null;
        }

        public async Task<bool> CreateCompany(CompanyForCreation companyDto)
        {

            // TODO Remove below and AutoMapp instead of
            var company = new Company
            {
                Name = companyDto.Name,
                Esite = companyDto.ESite,
                HomePhone = companyDto.HomePhone,
                Vat = companyDto.VAT
            };

            // TODO Remove below and AutoMapp instead of
            company.CompanyAddresses.Add(new CompanyAddress
            {
                Address = companyDto.PrincipalAddress,
                City = companyDto.City,
                ZipCode = companyDto.ZipCode,
                Country = companyDto.Country,
                CompanyAdressTypeId = CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress
            });

            await _repository.Create(company);

            return await _repository.Save();
        }

        public async Task<List<CompanyAddress>> GetAllAddresses()
        {
            return await _repoAddress.List().ToListAsync();
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _repository.List().ToListAsync();
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
            return await _repository.Get(companyId);
        }

        public async Task<bool> UpdateCompany(Company company)
        {
            if (company.CompanyAddresses.Where(ca => ca.CompanyAdressTypeId == CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress).Count() == 1)
            {
                _repository.Update(company);
                return await _repository.Save();
            }

            return false;
        }

        public async Task<bool> UpdateCompanyAddress(CompanyAddress companyAddress)
        {
            if (!await CompanyExists(companyAddress.CompanyId))
            {
                return false;
            }

            CheckAndMovePrincipalAddress(companyAddress);

            _repoAddress.Update(companyAddress);

            return await _repoAddress.Save();

        }

        private void CheckAndMovePrincipalAddress(CompanyAddressForCreation companyAddress)
        {
            // TODO remove below and AutoMapp instead of
            var companyAddressEntity = new CompanyAddress
            {
                CompanyId = companyAddress.CompanyId,
                Address =  companyAddress.Address,
                ZipCode = companyAddress.ZipCode,
                City = companyAddress.City,
                Country = companyAddress.Country,
                CompanyAdressTypeId = companyAddress.CompanyAdressTypeId
            };

            CheckAndMovePrincipalAddress(companyAddressEntity);
        }

        private void CheckAndMovePrincipalAddress(CompanyAddress companyAddress)
        {
            var company = _repository.Get(companyAddress.CompanyId);
            var companyAddresses = _repoAddress.List(ca => ca.CompanyId == company.Id);

            if (companyAddress.CompanyAdressTypeId == CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress
                && companyAddresses.Any(c => c.CompanyAdressTypeId == CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress))
            {
                var oldPrincipalAddress = companyAddresses
                    .First(c => c.CompanyAdressTypeId == CompanyAddressTypePartial.CompanyAddressTypeEnum.PrincipalAddress);
                oldPrincipalAddress.CompanyAdressTypeId = CompanyAddressTypePartial.CompanyAddressTypeEnum.Agency;

                _repoAddress.Update(oldPrincipalAddress);
            }
        }
    }
}
