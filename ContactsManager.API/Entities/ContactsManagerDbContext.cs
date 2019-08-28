using System;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.API.Entities
{
    public class ContactsManagerDbContext : DbContext
    {
        public ContactsManagerDbContext(DbContextOptions<ContactsManagerDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<CompanyAddressType> CompanyAddressTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<ContactCompanyRelationship> ContactCompanyRelationships { get; set; }
    }
}
