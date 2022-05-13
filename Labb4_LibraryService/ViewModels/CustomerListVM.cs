using Labb4_LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.ViewModels
{
    public class CustomerListVM
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
