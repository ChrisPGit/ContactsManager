
using System.ComponentModel.DataAnnotations;

namespace ContactsManager.API.Entities
{
    public class ContactCompanyRelationship
    {
        [Key]
        public int ContactCompanyIds { get; set; }
        public int ContactId { get; set; }
        public int CompanyId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Company Company { get; set; }
    }
}
