using System;
using System.Collections.Generic;

namespace ContactsManager.Data
{
    public partial class Company
    {
        public Company()
        {
            CompanyAddresses = new HashSet<CompanyAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Esite { get; set; }
        public string HomePhone { get; set; }
        public string Vat { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}
