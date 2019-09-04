using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Core.Dtos
{
    public class CompanyForCreation
    {
        [Required]
        public string Name { get; set; }
        public string ESite { get; set; }
        public string HomePhone { get; set; }
        [Required]
        public string VAT { get; set; }
        [Required]
        public string PrincipalAddress { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
