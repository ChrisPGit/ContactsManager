using System;
using System.Collections.Generic;

namespace ContactsManager.Data
{
    public partial class CompanyAddressType
    {
        public CompanyAddressType()
        {
            CompanyAddresses = new HashSet<CompanyAddress>();
        }

        public int Id { get; set; }
        public string InternalDescription { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}
