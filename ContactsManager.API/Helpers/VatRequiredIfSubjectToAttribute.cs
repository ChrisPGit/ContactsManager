using ContactsManager.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactsManager.API
{
    public class VatRequiredIfSubjectToAttribute : ValidationAttribute
    {
        public VatRequiredIfSubjectToAttribute()
        { }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var contact = (Contact)validationContext.ObjectInstance;
            if (contact.SubjectToVAT && string.IsNullOrWhiteSpace((string)value))
            {
                return new ValidationResult("The VAT number can be null or empty when a contact is subjetc to VAT");
            }
            return ValidationResult.Success;
        }
    }
}
