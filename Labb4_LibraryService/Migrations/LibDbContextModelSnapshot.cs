﻿// <auto-generated />
using System;
using Labb4_LibraryService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb4_LibraryService.Migrations
{
    [DbContext(typeof(LibDbContext))]
    partial class LibDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb4_LibraryService.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Lars Wilderäng",
                            Titel = "Drönarhjärta"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Tom Clancy",
                            Titel = "Jakten på Röd Oktober"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Lars Wilderäng",
                            Titel = "Höstsol"
                        },
                        new
                        {
                            Id = 4,
                            Author = "J.R.R. Tolkien",
                            Titel = "Sagan om Ringen"
                        },
                        new
                        {
                            Id = 5,
                            Author = "J.K. Rowling",
                            Titel = "Harry Potter och Fenixorden"
                        });
                });

            modelBuilder.Entity("Labb4_LibraryService.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "dexter@gmail.com",
                            Name = "Dexter",
                            Phone = "075-321 44 50"
                        },
                        new
                        {
                            Id = 2,
                            Email = "peggy@hotmail.com",
                            Name = "Peggy",
                            Phone = "010-569 96 33"
                        },
                        new
                        {
                            Id = 3,
                            Email = "atlas1337@yahoo.com",
                            Name = "Atlas",
                            Phone = "070-897 87 47"
                        },
                        new
                        {
                            Id = 4,
                            Email = "embla@myspace.com",
                            Name = "Embla",
                            Phone = "070-103 71 13"
                        },
                        new
                        {
                            Id = 5,
                            Email = "josh@guru.com",
                            Name = "Josh",
                            Phone = "070-567 31 00"
                        });
                });

            modelBuilder.Entity("Labb4_LibraryService.Models.Customer_Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BorrowDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Customer_Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            BorrowDate = new DateTime(1999, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            IsBorrowed = false,
                            ReturnDate = new DateTime(1999, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 4,
                            BorrowDate = new DateTime(2002, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 3,
                            IsBorrowed = false,
                            ReturnDate = new DateTime(2002, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            BorrowDate = new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            IsBorrowed = true
                        },
                        new
                        {
                            Id = 4,
                            BookId = 3,
                            BorrowDate = new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 5,
                            IsBorrowed = false,
                            ReturnDate = new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            BorrowDate = new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 4,
                            IsBorrowed = true
                        });
                });

            modelBuilder.Entity("Labb4_LibraryService.Models.Customer_Books", b =>
                {
                    b.HasOne("Labb4_LibraryService.Models.Book", "Book")
                        .WithMany("Customer_Books")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4_LibraryService.Models.Customer", "Customer")
                        .WithMany("Customer_Books")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
