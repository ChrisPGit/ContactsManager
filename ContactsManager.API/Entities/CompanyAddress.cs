using System.ComponentModel.DataAnnotations;

namespace ContactsManager.API.Entities
{
    public class CompanyAddress
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        [StringLength(150)]
        public string City { get; set; }
        [StringLength(100)]
        public string Country { get; set; }

        public int CompanyAdressTypeId { get; set; }
        public virtual CompanyAddressType CompanyAdressType { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
