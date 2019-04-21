﻿// <auto-generated />
using System;
using CuentasClaras.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CuentasClaras.Migrations
{
    [DbContext(typeof(CuentasClarasContext))]
    [Migration("20190421143350_Currencies")]
    partial class Currencies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CuentasClaras.Model.Buyer", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuyerExternalId");

                    b.Property<string>("Name");

                    b.HasKey("BuyerId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("CuentasClaras.Model.Currency", b =>
                {
                    b.Property<string>("CurrencyCode")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConversionFactorUYU")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(10,6)");

                    b.HasKey("CurrencyCode");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CuentasClaras.Model.Release", b =>
                {
                    b.Property<int>("ReleaseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Awards");

                    b.Property<int?>("BuyerId");

                    b.Property<string>("DataSource");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Id");

                    b.Property<string>("InitiationType");

                    b.Property<string>("Language");

                    b.Property<string>("Ocid");

                    b.Property<int?>("SupplierId");

                    b.Property<string>("Tag");

                    b.Property<string>("TenderDescription");

                    b.Property<DateTime?>("TenderEnquiryPeriodEndDate");

                    b.Property<DateTime?>("TenderEnquiryPeriodStartDate");

                    b.Property<bool?>("TenderHasEnquiries");

                    b.Property<string>("TenderId");

                    b.Property<string>("TenderProcurementMethod");

                    b.Property<string>("TenderProcurementMethodDetails");

                    b.Property<string>("TenderProcuringEntityId");

                    b.Property<string>("TenderProcuringEntityName");

                    b.Property<string>("TenderStatus");

                    b.Property<string>("TenderSubmissionMethod");

                    b.Property<string>("TenderSubmissionMethodDetails");

                    b.Property<DateTime?>("TenderTenderPeriodEndDate");

                    b.Property<DateTime?>("TenderTenderPeriodStartDate");

                    b.Property<string>("TenderTitle");

                    b.Property<double>("TotalAmountUYU");

                    b.HasKey("ReleaseId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("CuentasClaras.Model.ReleaseItem", b =>
                {
                    b.Property<int>("ReleaseItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("Description");

                    b.Property<string>("ExternalId");

                    b.Property<int>("Quantity");

                    b.Property<int?>("ReleaseId");

                    b.Property<int?>("ReleaseItemClassificationId");

                    b.Property<int>("TotalAmountUYU");

                    b.Property<int>("UnitId");

                    b.Property<string>("UnitName");

                    b.Property<double>("UnitValueAmount");

                    b.HasKey("ReleaseItemId");

                    b.HasIndex("ReleaseId");

                    b.HasIndex("ReleaseItemClassificationId");

                    b.ToTable("ReleaseItems");
                });

            modelBuilder.Entity("CuentasClaras.Model.ReleaseItemClassification", b =>
                {
                    b.Property<int>("ReleaseItemClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("ReleaseItemClassificationExternalId");

                    b.HasKey("ReleaseItemClassificationId");

                    b.ToTable("ReleaseItemClassifications");
                });

            modelBuilder.Entity("CuentasClaras.Model.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExternalId");

                    b.Property<string>("Name");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CuentasClaras.Model.Release", b =>
                {
                    b.HasOne("CuentasClaras.Model.Buyer", "Buyer")
                        .WithMany("Releases")
                        .HasForeignKey("BuyerId");

                    b.HasOne("CuentasClaras.Model.Supplier", "Supplier")
                        .WithMany("Releases")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("CuentasClaras.Model.ReleaseItem", b =>
                {
                    b.HasOne("CuentasClaras.Model.Release", "Release")
                        .WithMany("ReleaseItems")
                        .HasForeignKey("ReleaseId");

                    b.HasOne("CuentasClaras.Model.ReleaseItemClassification", "ReleaseItemClassification")
                        .WithMany("ReleaseItems")
                        .HasForeignKey("ReleaseItemClassificationId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
