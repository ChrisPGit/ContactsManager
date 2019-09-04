using ContactsManager.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.Data
{
    public static class ContactsManagerExtensions
    {
        public static void EnsureSeedDataForContext(this ContactsManagerContext context)
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
