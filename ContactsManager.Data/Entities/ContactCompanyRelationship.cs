using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.Data.Entities
{
    public class ContactCompanyRelationship
    {
        public int ContactId { get; set; }
        public int CompanyId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Company Company { get; set; }
    }

}
