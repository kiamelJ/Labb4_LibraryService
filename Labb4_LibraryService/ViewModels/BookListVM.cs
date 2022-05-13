using Labb4_LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.ViewModels
{
    public class BookListVM
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
