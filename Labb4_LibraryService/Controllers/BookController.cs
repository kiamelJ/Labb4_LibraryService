using Labb4_LibraryService.Interfaces;
using Labb4_LibraryService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Controllers
{
    public class BookController : Controller
    {

        //Dependency Injection
        private readonly IBookRepository _context;
        public BookController(IBookRepository context)
        {
            _context = context;
        }





        public async Task<IActionResult> BookList()
        {
            var bookList = await _context.GetAllAsync();
            return View(bookList);
        }
    }
}
