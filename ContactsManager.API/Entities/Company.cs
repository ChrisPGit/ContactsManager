using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsManager.API.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ESite { get; set; }
        [StringLength(25)]
        public string HomePhone { get; set; }
        [Required]
        public string VAT { get; set; }

        public ICollection<CompanyAddress> CompanyAddresses { get; set; }
        = new List<CompanyAddress>();
        [NotMapped]
        public virtual List<Contact> Contacts { get; set; }
    }
}
