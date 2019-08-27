using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Data.Entities
{
    public class CompanyAddressType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string InternalDescription { get; set; }
    }
}