﻿// <auto-generated />
using System;
using HospitalManagementProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagementProject.Migrations
{
    [DbContext(typeof(HospitalDBContext))]
    partial class HospitalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HospitalManagementProject.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Conclusion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FeedbackId")
                        .HasColumnType("int");

                    b.Property<int?>("MedStaffId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("PrescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackId");

                    b.HasIndex("MedStaffId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PrescriptionId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Conclusion = "Nice",
                            Date = new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MedStaffId = 1,
                            Status = 0
                        });
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Examination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppointmentPoint")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocterPoint")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.MedStaff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MedStaffs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Experience = "5 Years",
                            Qualification = "Havard"
                        });
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "X-Ray Pics",
                            Name = "X-Ray",
                            Price = 200.0
                        });
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Shifts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = new TimeSpan(0, 9, 0, 0, 0),
                            Start = new TimeSpan(0, 7, 30, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            End = new TimeSpan(0, 11, 0, 0, 0),
                            Start = new TimeSpan(0, 9, 30, 0, 0)
                        });
                });

            modelBuilder.Entity("HospitalManagementProject.Models.StaffShift", b =>
                {
                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<int>("MedStaffId")
                        .HasColumnType("int");

                    b.HasKey("ShiftId", "MedStaffId");

                    b.HasIndex("MedStaffId");

                    b.ToTable("StaffShifts");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MedStaffId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("MedStaffId")
                        .IsUnique()
                        .HasFilter("[MedStaffId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PatientId")
                        .IsUnique()
                        .HasFilter("[PatientId] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "743a03be-1913-4102-b722-b193b48d99e5",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "5613211f-ce46-47b9-8602-903616fdc303",
                            Name = "PATIENT",
                            NormalizedName = "PATIENT"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "179212b5-01a5-4d77-98b0-31232199eafa",
                            Name = "DOCTOR",
                            NormalizedName = "DOCTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Appointment", b =>
                {
                    b.HasOne("HospitalManagementProject.Models.Feedback", "Feedback")
                        .WithMany()
                        .HasForeignKey("FeedbackId");

                    b.HasOne("HospitalManagementProject.Models.MedStaff", "MedStaff")
                        .WithMany("Appointments")
                        .HasForeignKey("MedStaffId");

                    b.HasOne("HospitalManagementProject.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId");

                    b.HasOne("HospitalManagementProject.Models.Prescription", "Prescription")
                        .WithMany()
                        .HasForeignKey("PrescriptionId");

                    b.HasOne("HospitalManagementProject.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId");

                    b.Navigation("Feedback");

                    b.Navigation("MedStaff");

                    b.Navigation("Patient");

                    b.Navigation("Prescription");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Examination", b =>
                {
                    b.HasOne("HospitalManagementProject.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementProject.Models.Service", "Service")
                        .WithMany("Examinations")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.StaffShift", b =>
                {
                    b.HasOne("HospitalManagementProject.Models.MedStaff", "MedStaff")
                        .WithMany("StaffShifts")
                        .HasForeignKey("MedStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementProject.Models.Shift", "Shift")
                        .WithMany("StaffShift")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedStaff");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.User", b =>
                {
                    b.HasOne("HospitalManagementProject.Models.MedStaff", "MedStaff")
                        .WithOne("User")
                        .HasForeignKey("HospitalManagementProject.Models.User", "MedStaffId");

                    b.HasOne("HospitalManagementProject.Models.Patient", "Patient")
                        .WithOne("User")
                        .HasForeignKey("HospitalManagementProject.Models.User", "PatientId");

                    b.Navigation("MedStaff");

                    b.Navigation("Patient");
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
                    b.HasOne("HospitalManagementProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HospitalManagementProject.Models.User", null)
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

                    b.HasOne("HospitalManagementProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HospitalManagementProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalManagementProject.Models.MedStaff", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("StaffShifts");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Service", b =>
                {
                    b.Navigation("Examinations");
                });

            modelBuilder.Entity("HospitalManagementProject.Models.Shift", b =>
                {
                    b.Navigation("StaffShift");
                });
#pragma warning restore 612, 618
        }
    }
}
