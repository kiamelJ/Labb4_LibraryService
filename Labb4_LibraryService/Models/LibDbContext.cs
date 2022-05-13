using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Models
{
    public class LibDbContext : DbContext
    {
        public LibDbContext(DbContextOptions<LibDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer_Books> Customer_Books { get; set; }

        //Tidigare här har jag gjort OnModelCreating för att skapa composite key av 
        //FK som finns i join table men eftersom jag nu har satt en egen PK så lär jag inte behöva det....tror jag.
        //Jag får testa å se.


        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Customer>()
                .HasData(
                new Customer { Id = 1, Name = "Dexter", Phone = "075-321 44 50", Email = "dexter@gmail.com"},
                new Customer { Id = 2, Name = "Peggy", Phone = "010-569 96 33", Email = "peggy@hotmail.com"},
                new Customer { Id = 3, Name = "Atlas", Phone = "070-897 87 47", Email = "atlas1337@yahoo.com"},
                new Customer { Id = 4, Name = "Embla", Phone = "070-103 71 13", Email = "embla@myspace.com"},
                new Customer { Id = 5, Name = "Josh", Phone = "070-567 31 00", Email = "josh@guru.com"}
                );

            mb.Entity<Book>()
                .HasData(
                new Book { Id = 1, Titel = "Drönarhjärta", Author = "Lars Wilderäng"},
                new Book { Id = 2, Titel = "Jakten på Röd Oktober", Author = "Tom Clancy"},
                new Book { Id = 3, Titel = "Höstsol", Author = "Lars Wilderäng"},
                new Book { Id = 4, Titel = "Sagan om Ringen", Author = "J.R.R. Tolkien"},
                new Book { Id = 5, Titel = "Harry Potter och Fenixorden", Author = "J.K. Rowling"}
                );

            mb.Entity<Customer_Books>()
                .HasData(
                new Customer_Books { Id = 1, CustomerId = 2, BookId = 1, BorrowDate = new DateTime(1999, 03, 13), ReturnDate = new DateTime(1999, 04, 07), IsBorrowed = false},
                new Customer_Books { Id = 2, CustomerId = 3, BookId = 4, BorrowDate = new DateTime(2002, 10, 05), ReturnDate = new DateTime(2002, 10, 27), IsBorrowed = false},
                new Customer_Books { Id = 3, CustomerId = 1, BookId = 2, BorrowDate = new DateTime(2022, 10, 05), IsBorrowed = true},
                new Customer_Books { Id = 4, CustomerId = 5, BookId = 3, BorrowDate = new DateTime(2022, 01, 13), ReturnDate = new DateTime(2022, 01, 30), IsBorrowed = false },
                new Customer_Books { Id = 5, CustomerId = 4, BookId = 5, BorrowDate = new DateTime(2022, 04, 15), IsBorrowed = true}
                );
        }
    }
}
