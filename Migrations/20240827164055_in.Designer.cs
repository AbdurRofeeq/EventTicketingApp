﻿// <auto-generated />
using System;
using EventTicketingApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventTicketingApp.Migrations
{
    [DbContext(typeof(EventTicketingAppContext))]
    [Migration("20240827164055_in")]
    partial class @in
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Attendee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.AttendeeTicketRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AttendeeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<int>("TicketCount")
                        .HasColumnType("int");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketId");

                    b.ToTable("AttendeeTicketRecords");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EventOrganizerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Venue")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventOrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.EventOrganizer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CertificationImage")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EventOrganizers");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("05f27dec-5c62-4266-a475-a75f2b84e33a"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("77d6f378-7bf8-4a33-976c-ecb768ab8503"),
                            Name = "EventOrganizer"
                        },
                        new
                        {
                            Id = new Guid("bd36a9f9-a6cd-4ab9-890d-65bba21d028f"),
                            Name = "Attendee"
                        });
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AttendeeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("QRCode")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.HasIndex("EventId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Ticket")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TransactionReference")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c19fc9cb-d13b-4d0c-a6b2-480609acef99"),
                            Email = "admin@gmail.com",
                            PasswordHash = "$2a$10$FEQembmBCqkzEuv0SipnNOVy5.lmLk3EFGwvbMkq5/cSTKIec80Q6",
                            RoleId = new Guid("05f27dec-5c62-4266-a475-a75f2b84e33a"),
                            Salt = "$2a$10$FEQembmBCqkzEuv0SipnNO",
                            UserName = "CEO"
                        });
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Wallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Wallets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4446452d-0d9d-464b-8612-83c39bba2722"),
                            Balance = 0m,
                            UserId = new Guid("c19fc9cb-d13b-4d0c-a6b2-480609acef99")
                        });
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Attendee", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.AttendeeTicketRecord", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.Attendee", "Attendee")
                        .WithMany("TicketRecords")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventTicketingApp.Core.Domain.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventTicketingApp.Core.Domain.Entities.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Event");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Event", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.EventOrganizer", "Organizer")
                        .WithMany("EventsCreated")
                        .HasForeignKey("EventOrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.EventOrganizer", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.Attendee", "Attendee")
                        .WithMany("Tickets")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventTicketingApp.Core.Domain.Entities.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.User", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("EventTicketingApp.Core.Domain.Entities.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("EventTicketingApp.Core.Domain.Entities.Wallet", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Attendee", b =>
                {
                    b.Navigation("TicketRecords");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.EventOrganizer", b =>
                {
                    b.Navigation("EventsCreated");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("Wallet")
                        .IsRequired();
                });

            modelBuilder.Entity("EventTicketingApp.Core.Domain.Entities.Wallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
