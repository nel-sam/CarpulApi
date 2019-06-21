﻿// <auto-generated />
using System;
using CarpoolApi.Infastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarpoolApi.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190601170850_reseedData")]
    partial class reseedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarpoolApi.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("State");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Campus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Campuses");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.CampusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("CampusTypes");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.CampusTypeCampus", b =>
                {
                    b.Property<int>("CampusId");

                    b.Property<int>("CampusTypeId");

                    b.HasKey("CampusId", "CampusTypeId");

                    b.HasIndex("CampusTypeId");

                    b.ToTable("CampusTypeCampuses");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarpoolId");

                    b.Property<string>("Color");

                    b.Property<string>("LicensePlateNo");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CarpoolId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Carpool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CampusId");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Carpools");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarpoolId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<int?>("IncentiveTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CarpoolId");

                    b.HasIndex("IncentiveTypeId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.IncentiveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique()
                        .HasFilter("[Description] IS NOT NULL");

                    b.ToTable("IncentiveTypes");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Name");

                    b.Property<int?>("PhoneNumberId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("PhoneNumberId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.OrganizationCampus", b =>
                {
                    b.Property<int>("CampusId");

                    b.Property<int>("OrganizationId");

                    b.HasKey("CampusId", "OrganizationId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrganizationCampuses");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaCode");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Request", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("CarpoolId");

                    b.Property<int>("Approval");

                    b.Property<string>("Message");

                    b.HasKey("UserId", "CarpoolId");

                    b.HasIndex("CarpoolId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int?>("CarpoolId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int?>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CarpoolId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.UserCar", b =>
                {
                    b.Property<int>("CarId");

                    b.Property<int>("UserId");

                    b.HasKey("CarId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCars");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.UserPhone", b =>
                {
                    b.Property<int>("PhoneNumberId");

                    b.Property<int>("UserId");

                    b.HasKey("PhoneNumberId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhones");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique()
                        .HasFilter("[Type] IS NOT NULL");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Campus", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.CampusTypeCampus", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Campus", "Campus")
                        .WithMany("CampusTypeCampuses")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarpoolApi.Domain.Models.CampusType", "CampusType")
                        .WithMany("CampusTypeCampuses")
                        .HasForeignKey("CampusTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Car", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Carpool", "Carpool")
                        .WithMany("Cars")
                        .HasForeignKey("CarpoolId");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Carpool", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Campus", "Campus")
                        .WithMany()
                        .HasForeignKey("CampusId");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Certificate", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Carpool", "Carpool")
                        .WithMany("Certificates")
                        .HasForeignKey("CarpoolId");

                    b.HasOne("CarpoolApi.Domain.Models.IncentiveType", "IncentiveType")
                        .WithMany()
                        .HasForeignKey("IncentiveTypeId");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Organization", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Address", "Address")
                        .WithMany("Organizations")
                        .HasForeignKey("AddressId");

                    b.HasOne("CarpoolApi.Domain.Models.PhoneNumber", "PhoneNumber")
                        .WithMany()
                        .HasForeignKey("PhoneNumberId");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.OrganizationCampus", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Campus", "Campus")
                        .WithMany("OrganizationCampuses")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarpoolApi.Domain.Models.Organization", "Organization")
                        .WithMany("OrganizationCampuses")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.Request", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Carpool", "Carpool")
                        .WithMany("Requests")
                        .HasForeignKey("CarpoolId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarpoolApi.Domain.Models.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.User", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("CarpoolApi.Domain.Models.Carpool", "Carpool")
                        .WithMany("Users")
                        .HasForeignKey("CarpoolId");

                    b.HasOne("CarpoolApi.Domain.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId");
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.UserCar", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.Car", "Car")
                        .WithMany("UserCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarpoolApi.Domain.Models.User", "User")
                        .WithMany("UserCars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarpoolApi.Domain.Models.UserPhone", b =>
                {
                    b.HasOne("CarpoolApi.Domain.Models.PhoneNumber", "PhoneNumber")
                        .WithMany("UserPhoneNumbers")
                        .HasForeignKey("PhoneNumberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarpoolApi.Domain.Models.User", "User")
                        .WithMany("UserPhones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
