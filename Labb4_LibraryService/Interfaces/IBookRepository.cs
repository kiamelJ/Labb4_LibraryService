using Labb4_LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks { get;  }
    }
}
