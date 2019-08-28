using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.API.Dtos
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
