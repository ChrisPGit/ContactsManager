using System;
using System.Collections.Generic;

namespace ContactsManager.Core.Entities
{
    public partial class Company : EntityBase
    {
        public Company()
        {
            CompanyAddresses = new HashSet<CompanyAddress>();
        }

        public string Name { get; set; }
        public string Esite { get; set; }
        public string HomePhone { get; set; }
        public string Vat { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}
