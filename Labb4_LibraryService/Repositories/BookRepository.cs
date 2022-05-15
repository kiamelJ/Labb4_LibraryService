using Labb4_LibraryService.Interfaces;
using Labb4_LibraryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Repositories
{
    public class BookRepository : EntityBaseRepository<Book>, IBookRepository
    {
        private readonly LibDbContext _context;
        public BookRepository(LibDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(pb => pb.Customer_Books)
                .ThenInclude(c => c.Customer)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails;
        }
    }
}
