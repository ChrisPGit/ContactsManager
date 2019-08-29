using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactsManager.Data
{
    public partial class ContactsManagerContext : DbContext
    {
        public ContactsManagerContext()
        {
        }

        public ContactsManagerContext(DbContextOptions<ContactsManagerContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyAddressType> CompanyAddressTypes { get; set; }
        public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactCompanyRelationship> ContactCompanyRelationships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Esite).HasColumnName("ESite");

                entity.Property(e => e.HomePhone).HasMaxLength(25);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Vat)
                    .IsRequired()
                    .HasColumnName("VAT");
            });

            modelBuilder.Entity<CompanyAddressType>(entity =>
            {
                entity.Property(e => e.InternalDescription).HasMaxLength(200);
            });

            modelBuilder.Entity<CompanyAddress>(entity =>
            {
                entity.HasIndex(e => e.CompanyAdressTypeId);

                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.HasOne(d => d.CompanyAdressType)
                    .WithMany(p => p.CompanyAddresses)
                    .HasForeignKey(d => d.CompanyAdressTypeId);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyAddresses)
                    .HasForeignKey(d => d.CompanyId);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Mobile).HasMaxLength(25);

                entity.Property(e => e.SubjectToVat).HasColumnName("SubjectToVAT");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("ZIP");
            });

            modelBuilder.Entity<ContactCompanyRelationship>()
                .HasKey(table => new { table.ContactId, table.CompanyId });
        }
    }
}
