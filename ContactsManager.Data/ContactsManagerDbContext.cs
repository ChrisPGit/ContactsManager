using ContactsManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsManager.Data
{
    public class ContactsManagerDbContext : DbContext
    {
        public ContactsManagerDbContext(DbContextOptions<ContactsManagerDbContext> options)
            : base(options)
        {

        }

        public DbSet<CompanyAddressType> CompanyAddressTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<ContactCompanyRelationship> ContactCompanyRelationships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ContactsManager;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ContactCompanyRelationship>()
        //        .HasKey(o => new { o.ContactId, o.CompanyId });
        //}
    }
}
