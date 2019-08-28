﻿// <auto-generated />
using ContactsManager.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactsManager.API.Migrations
{
    [DbContext(typeof(ContactsManagerDbContext))]
    [Migration("20190828104245_Relationship")]
    partial class Relationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsManager.API.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ESite");

                    b.Property<string>("HomePhone")
                        .HasMaxLength(25);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("VAT")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ContactsManager.API.Entities.CompanyAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City")
                        .HasMaxLength(150);

                    b.Property<int>("CompanyAdressTypeId");

                    b.Property<int>("CompanyId");

                    b.Property<string>("Country")
                        .HasMaxLength(100);

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("CompanyAdressTypeId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAddresses");
                });

            modelBuilder.Entity("ContactsManager.API.Entities.CompanyAddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InternalDescription")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("CompanyAddressTypes");
                });

            modelBuilder.Entity("ContactsManager.API.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Mobile")
                        .HasMaxLength(25);

                    b.Property<bool>("SubjectToVAT");

                    b.Property<string>("VAT");

                    b.Property<string>("ZIP")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactsManager.API.Entities.CompanyAddress", b =>
                {
                    b.HasOne("ContactsManager.API.Entities.CompanyAddressType", "CompanyAdressType")
                        .WithMany()
                        .HasForeignKey("CompanyAdressTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ContactsManager.API.Entities.Company", "Company")
                        .WithMany("CompanyAddresses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
