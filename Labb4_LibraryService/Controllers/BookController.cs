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

        //DI
        private readonly IBookRepository _bookRepo;
        private readonly ICustomerRepository _customerRepo;
        public BookController(IBookRepository bookRepo, ICustomerRepository customerRepo)
        {
            _bookRepo = bookRepo;
            _customerRepo = customerRepo;
        }



        public IActionResult BookList()
        {

            var bookList = _bookRepo.GetAllBooks;
            return View(bookList);
        }
    }
}
