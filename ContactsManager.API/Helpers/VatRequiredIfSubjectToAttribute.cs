using ContactsManager.API.Dtos;
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
            var contact = (ContactForCreation)validationContext.ObjectInstance;
            if (contact.SubjectToVAT && string.IsNullOrWhiteSpace((string)value))
            {
                return new ValidationResult("The VAT number can be null or empty when a contact is subjetc to VAT");
            }
            return ValidationResult.Success;
        }
    }
}
