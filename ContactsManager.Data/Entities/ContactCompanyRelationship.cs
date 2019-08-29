
using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Data
{
    public class ContactCompanyRelationship
    {
        public int ContactId { get; set; }
        public int CompanyId { get; set; }
    }
}
