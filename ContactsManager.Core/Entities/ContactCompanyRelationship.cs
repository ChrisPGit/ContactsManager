
using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Core.Entities
{
    public class ContactCompanyRelationship
    {
        public int ContactId { get; set; }
        public int CompanyId { get; set; }
    }
}
