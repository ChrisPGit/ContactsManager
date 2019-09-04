using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.Core.Dtos
{
    public class CompanyAddressForCreation
    {
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CompanyAdressTypeId { get; set; }
        public int CompanyId { get; set; }
    }
}
