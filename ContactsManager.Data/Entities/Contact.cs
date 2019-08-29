﻿using System;
using System.Collections.Generic;

namespace ContactsManager.Data
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool SubjectToVat { get; set; }
        public string Vat { get; set; }
    }
}
