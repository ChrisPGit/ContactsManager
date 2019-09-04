using System;
using System.Collections.Generic;

namespace ContactsManager.Core.Entities
{
    public partial class CompanyAddress : EntityBase
    {
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CompanyAdressTypeId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual CompanyAddressType CompanyAdressType { get; set; }
    }
}
