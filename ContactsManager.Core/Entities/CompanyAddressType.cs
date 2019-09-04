using System;
using System.Collections.Generic;

namespace ContactsManager.Core.Entities
{
    public partial class CompanyAddressType : EntityBase
    {
        public CompanyAddressType()
        {
            CompanyAddresses = new HashSet<CompanyAddress>();
        }

        public string InternalDescription { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}
