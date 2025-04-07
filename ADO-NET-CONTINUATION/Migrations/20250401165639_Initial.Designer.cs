﻿// <auto-generated />
using System;
using ADO_NET_CONTINUATION.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ADO_NET_CONTINUATION.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250401165639_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ADO_NET_CONTINUATION.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7687bebd-e8a3-4b28-abc8-8fc9cc403a8d"),
                            Birthdate = new DateTime(1998, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "landau14@gmail.com",
                            Name = "Lev Landau",
                            RegisteredAt = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("bdf41cd9-c0f1-4349-8a44-4e67755d0415"),
                            Birthdate = new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sivukhon51gmail.com",
                            Name = "Dmitri Sivukhin",
                            RegisteredAt = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("03767d46-aab3-4cc4-989c-a696a7fdd434"),
                            Birthdate = new DateTime(1989, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "shostakovich178gmail.com",
                            Name = "Dmitri Shostakovich",
                            RegisteredAt = new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0d156354-89f1-4d58-a735-876b7add59d2"),
                            Birthdate = new DateTime(2005, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "astread35gmail.com",
                            Name = "Ruu Lion",
                            RegisteredAt = new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a3c55a79-05ea-4053-ad3c-7301f3b7a7e2"),
                            Birthdate = new DateTime(2005, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cranel757gmail.com",
                            Name = "Bell Cranel",
                            RegisteredAt = new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("eadb0b3b-523e-478b-88ee-b6cf57cbc05d"),
                            Birthdate = new DateTime(2001, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "takt21@gmail.com",
                            Name = "Task Asahina",
                            RegisteredAt = new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a0f7b463-6eef-4a70-8444-789bbea23369"),
                            Birthdate = new DateTime(1999, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "yuuki15@gmail.com",
                            Name = "Asuna Yuuki",
                            RegisteredAt = new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ADO_NET_CONTINUATION.Data.Entities.UserAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("UsersAccesses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e29b6a1a-5bc7-4f42-9fa4-db25de342b42"),
                            Dk = "Salt1123",
                            Login = "jakiv",
                            RoleId = "SelfRegistered",
                            Salt = "Salt1",
                            UserId = new Guid("7687bebd-e8a3-4b28-abc8-8fc9cc403a8d")
                        },
                        new
                        {
                            Id = new Guid("fb4ad18c-d916-4708-be71-a9bbcf1eb806"),
                            Dk = "Salt2123",
                            Login = "storozh",
                            RoleId = "Employee",
                            Salt = "Salt2",
                            UserId = new Guid("bdf41cd9-c0f1-4349-8a44-4e67755d0415")
                        },
                        new
                        {
                            Id = new Guid("b31355b7-aa02-4b10-afda-eb9ec8294e78"),
                            Dk = "Salt3123",
                            Login = "dnistr",
                            RoleId = "SelfRegistered",
                            Salt = "Salt3",
                            UserId = new Guid("03767d46-aab3-4cc4-989c-a696a7fdd434")
                        },
                        new
                        {
                            Id = new Guid("92cd36b8-ea5a-4cbb-a232-268d942c97fd"),
                            Dk = "Salt4123",
                            Login = "dina",
                            RoleId = "Employee",
                            Salt = "Salt4",
                            UserId = new Guid("0d156354-89f1-4d58-a735-876b7add59d2")
                        },
                        new
                        {
                            Id = new Guid("7a38a3aa-de9f-4519-bb48-eeb86c1efcdf"),
                            Dk = "Salt5123",
                            Login = "dina@ukr.net",
                            RoleId = "Moderator",
                            Salt = "Salt5",
                            UserId = new Guid("0d156354-89f1-4d58-a735-876b7add59d2")
                        },
                        new
                        {
                            Id = new Guid("f1ea6b3f-0021-417b-95c8-f6cd333d7207"),
                            Dk = "Salt6123",
                            Login = "romashko",
                            RoleId = "SelfRegistered",
                            Salt = "Salt6",
                            UserId = new Guid("a3c55a79-05ea-4053-ad3c-7301f3b7a7e2")
                        },
                        new
                        {
                            Id = new Guid("8806ca58-8daa-4576-92ba-797de42ffaa7"),
                            Dk = "Salt7123",
                            Login = "erstenuk",
                            RoleId = "Employee",
                            Salt = "Salt7",
                            UserId = new Guid("eadb0b3b-523e-478b-88ee-b6cf57cbc05d")
                        },
                        new
                        {
                            Id = new Guid("97191468-a02f-4a78-927b-9ea660e9ea36"),
                            Dk = "Salt8123",
                            Login = "erstenuk@ukr.net",
                            RoleId = "Administrator",
                            Salt = "Salt8",
                            UserId = new Guid("eadb0b3b-523e-478b-88ee-b6cf57cbc05d")
                        },
                        new
                        {
                            Id = new Guid("6a1d3de4-0d78-4d7d-8f6a-9e52694ff2ee"),
                            Dk = "Salt9123",
                            Login = "bondarko",
                            RoleId = "SelfRegistered",
                            Salt = "Salt9",
                            UserId = new Guid("a0f7b463-6eef-4a70-8444-789bbea23369")
                        });
                });

            modelBuilder.Entity("ADO_NET_CONTINUATION.Data.Entities.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CanCreate")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("CanRead")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersRoles");

                    b.HasData(
                        new
                        {
                            Id = "SelfRegistered",
                            CanCreate = false,
                            CanDelete = false,
                            CanRead = false,
                            CanUpdate = false,
                            Description = "Self-registered user"
                        },
                        new
                        {
                            Id = "Employee",
                            CanCreate = true,
                            CanDelete = false,
                            CanRead = true,
                            CanUpdate = false,
                            Description = "Company's employee"
                        },
                        new
                        {
                            Id = "Moderator",
                            CanCreate = false,
                            CanDelete = true,
                            CanRead = true,
                            CanUpdate = true,
                            Description = "Content editor"
                        },
                        new
                        {
                            Id = "Administrator",
                            CanCreate = true,
                            CanDelete = true,
                            CanRead = true,
                            CanUpdate = true,
                            Description = "System administrator"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
