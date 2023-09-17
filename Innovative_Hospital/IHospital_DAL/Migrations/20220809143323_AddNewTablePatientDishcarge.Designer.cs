﻿// <auto-generated />
using System;
using Innovative_Hospital_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Innovative_Hospital_DAL.Migrations
{
    [DbContext(typeof(IHospitalDbContext))]
    [Migration("20220809143323_AddNewTablePatientDishcarge")]
    partial class AddNewTablePatientDishcarge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.DoctorInstruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccountingId")
                        .HasColumnType("int");

                    b.Property<string>("Analyzes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorInstructions");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.MedicalCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Allergy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<string>("Disability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diseases")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("HomePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfWork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionAtWork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<string>("WorkPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicalCards");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.PatientAccounting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDischarge")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullNamePatient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDischarged")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicalCardId")
                        .HasColumnType("int");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("PatientAccountings");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.PatientDischarge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccountingId")
                        .HasColumnType("int");

                    b.Property<string>("Disease")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullNameDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNamePatient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecommendationsForDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.HasIndex("DoctorId");

                    b.ToTable("PatientDischarge");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<int>("FreeBads")
                        .HasColumnType("int");

                    b.Property<int>("MaxBads")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("RoomNumber")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.TaskOfJuniorNurse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccountingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCreateTask")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("JuniorNurseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SeniorNurseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Task")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountingId");

                    b.HasIndex("JuniorNurseId");

                    b.HasIndex("SeniorNurseId");

                    b.ToTable("TaskOfJuniorNurses");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronomyc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Employee", b =>
                {
                    b.HasBaseType("Innovative_Hospital_DAL.Models.User");

                    b.Property<DateTime?>("DateOfDismissal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFired")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Patient", b =>
                {
                    b.HasBaseType("Innovative_Hospital_DAL.Models.User");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInTheHospital")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicalCardId")
                        .HasColumnType("int");

                    b.HasIndex("MedicalCardId")
                        .IsUnique()
                        .HasFilter("[MedicalCardId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Doctor", b =>
                {
                    b.HasBaseType("Innovative_Hospital_DAL.Models.Employee");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.HasIndex("DepartamentId");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Nurse", b =>
                {
                    b.HasBaseType("Innovative_Hospital_DAL.Models.Employee");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Nurse");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.DoctorInstruction", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.PatientAccounting", "PatientAccounting")
                        .WithMany("DoctorInstructions")
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innovative_Hospital_DAL.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Innovative_Hospital_DAL.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("PatientAccounting");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.PatientAccounting", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.Departament", "Departament")
                        .WithMany("PatientAccountings")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innovative_Hospital_DAL.Models.Doctor", "Doctor")
                        .WithMany("PatientAccountings")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Innovative_Hospital_DAL.Models.Patient", "Patient")
                        .WithMany("PatientAccountings")
                        .HasForeignKey("PatientId");

                    b.HasOne("Innovative_Hospital_DAL.Models.Room", "Room")
                        .WithMany("PatientAccountings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.PatientDischarge", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.PatientAccounting", "PatientAccounting")
                        .WithMany()
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innovative_Hospital_DAL.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.Navigation("Doctor");

                    b.Navigation("PatientAccounting");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Room", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.Departament", "Departament")
                        .WithMany("Rooms")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.TaskOfJuniorNurse", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.PatientAccounting", "PatientAccounting")
                        .WithMany()
                        .HasForeignKey("AccountingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innovative_Hospital_DAL.Models.Nurse", "JuniorNurse")
                        .WithMany()
                        .HasForeignKey("JuniorNurseId");

                    b.HasOne("Innovative_Hospital_DAL.Models.Nurse", "SeniorNurse")
                        .WithMany()
                        .HasForeignKey("SeniorNurseId");

                    b.Navigation("JuniorNurse");

                    b.Navigation("PatientAccounting");

                    b.Navigation("SeniorNurse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innovative_Hospital_DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Patient", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.MedicalCard", "MedicalCard")
                        .WithOne("Patient")
                        .HasForeignKey("Innovative_Hospital_DAL.Models.Patient", "MedicalCardId");

                    b.Navigation("MedicalCard");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Doctor", b =>
                {
                    b.HasOne("Innovative_Hospital_DAL.Models.Departament", "Departament")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Departament", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("PatientAccountings");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.MedicalCard", b =>
                {
                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.PatientAccounting", b =>
                {
                    b.Navigation("DoctorInstructions");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Room", b =>
                {
                    b.Navigation("PatientAccountings");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Patient", b =>
                {
                    b.Navigation("PatientAccountings");
                });

            modelBuilder.Entity("Innovative_Hospital_DAL.Models.Doctor", b =>
                {
                    b.Navigation("PatientAccountings");
                });
#pragma warning restore 612, 618
        }
    }
}
