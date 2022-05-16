using Labb4_LibraryService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Controllers
{
    public class BookController : Controller
    {

        
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

        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _context.GetBookByIdAsync(id);
            return View(bookDetail);
        }

    }
}
