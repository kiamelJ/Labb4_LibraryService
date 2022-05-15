using Labb4_LibraryService.Interfaces;
using Labb4_LibraryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Repositories
{
    public class CustomerRepository : EntityBaseRepository<Customer>, ICustomerRepository
    {
        private readonly LibDbContext _context;
        public CustomerRepository(LibDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var personDetails = await _context.Customers
                .Include(pb => pb.Customer_Books)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(n => n.Id == id);

            return personDetails;
        }
    }
}
