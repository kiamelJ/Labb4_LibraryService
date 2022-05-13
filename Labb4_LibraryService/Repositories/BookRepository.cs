using Labb4_LibraryService.Interfaces;
using Labb4_LibraryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibDbContext _libContext;
        public BookRepository(LibDbContext libContext)
        {
            _libContext = libContext;
        }

        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                //Det är nåt med Customer_Books tror jag för det är den som
                //bråkade när jag gjorde en join också

                //return _libContext.Customer_Books.Include(b => b.Book).ToList();

                return _libContext.Books.ToList();

            }
        }
    }
}
