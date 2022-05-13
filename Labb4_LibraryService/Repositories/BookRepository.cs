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
                return _libContext.Books.ToList();
            }
        }
    }
}
