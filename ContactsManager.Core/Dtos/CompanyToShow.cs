using ContactsManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.Core.Dtos
{
    public class CompanyToShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ESite { get; set; }
        public string HomePhone { get; set; }
        public string VAT { get; set; }

        public List<CompanyAddress> CompanyAddresses { get; set; }


    }
}
