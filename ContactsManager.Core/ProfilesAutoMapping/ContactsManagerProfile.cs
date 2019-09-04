using AutoMapper;
using ContactsManager.Core.Dtos;
using ContactsManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.Core.ProfilesAutoMapping
{
    public class ContactsManagerProfile : Profile
    {
        public ContactsManagerProfile()
        {
            CreateMap<CompanyAddressForCreation, CompanyAddress>();
            CreateMap<Company, CompanyToShow>();

        }
    }
}
