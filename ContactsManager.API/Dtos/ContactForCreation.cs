using System.ComponentModel.DataAnnotations;

namespace ContactsManager.API.Dtos
{
    public class ContactForCreation
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ZIP { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public string Email { get; set; }
        [StringLength(25)]
        public string Mobile { get; set; }

        //Instead of Freelance or Employee we define if he is subject to VAT or not ???
        public bool SubjectToVAT { get; set; }

        [VatRequiredIfSubjectTo]
        public string VAT { get; set; }

    }
}
