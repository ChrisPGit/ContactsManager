using ContactsManager.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Data
{
    public class VatRequiredIfSubjectToAttribute : ValidationAttribute
    {
        public VatRequiredIfSubjectToAttribute()
        {

        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var contact = (Contact)validationContext.ObjectInstance;
            if (contact.SubjectToVAT && string.IsNullOrWhiteSpace((string)value))
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return "The VAT number can be null or empty when a contact is subjetc to VAT";
        }
    }
}
