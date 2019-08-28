using ContactsManager.API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.API.Helpers
{
    public static class ContactsManagerExtensions
    {
        public static void EnsureSeedDataForContext(this ContactsManagerDbContext context)
        {
            if (context.CompanyAddressTypes.Any())
            {
                return;
            }

            var companyAddresstypes = new List<string>
            {
                "Principal address",
                "Invoicing address",
                "Agency"
            };

            foreach (var addressType in companyAddresstypes)
            {
                context.CompanyAddressTypes.Add(new CompanyAddressType
                {
                    InternalDescription = addressType
                });
            }

            context.SaveChanges(true);
        }
    }
}
