using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.API.Entities
{
    public partial class CompanyAddressTypePartial : CompanyAddressType
    {
        public static class CompanyAddressTypeEnum
        {
            public static int PrincipalAddress = 1;
            public static int InvoicingAddress = 2;
            public static int Agency = 3;
        }
    }
}
