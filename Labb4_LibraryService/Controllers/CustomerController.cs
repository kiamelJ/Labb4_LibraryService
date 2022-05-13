using Labb4_LibraryService.Interfaces;
using Labb4_LibraryService.Models;
using Labb4_LibraryService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Controllers
{
    public class CustomerController : Controller
    {
        //Dependency Injection
        private readonly ICustomerRepository _customerRepo;
        private readonly IBookRepository _bookRepo;
        public CustomerController(ICustomerRepository customerRepo, IBookRepository bookRepo)
        {
            _customerRepo = customerRepo;
            _bookRepo = bookRepo;
        }

       

        //GET ALL CUSTOMER
        public IActionResult List()
        {
            var customerList = _customerRepo.GetAllCustomers;
            return View(customerList);
        }

        //*******************************************************************************************

        //Den här hör till Create så att sidan visas tom först utan varningar om validering
        public IActionResult CreateCustomer()
        {
            return View();
        }

        //CREATE NEW CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.CreateCustomer(customer);
                return RedirectToAction("List");
            }
            return View(customer);
        }

        //********************************************************************************************

        //GET - GetById
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerRepo.GetCustomerById(id);
            return View(customer);
        }

        //********************************************************************************************

        // Först hämtar man personen sedan editerar man. Samma nedan i Delete


        //GET - Edit
        public IActionResult EditCustomer(int id)
        {
            var customerToEdit = _customerRepo.GetCustomerById(id);
            return View(customerToEdit);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.UpdateCustomer(customer);
                return RedirectToAction("List");
            }
            return View(customer);
        }

        //********************************************************************************************

        //Först hämtar vi personen sedan deletar vi den

        //GET - Delete
        public IActionResult DeleteCustomer(int id)
        {
            var customerToDel = _customerRepo.GetCustomerById(id);
            return View(customerToDel);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var customerToDelete = _customerRepo.GetCustomerById(id);

            _customerRepo.DeleteCustomer(customerToDelete);
            return RedirectToAction("List");
                
        }

        //*************************************************************************

        //TEST SEARCH FUNCTIONALITY

        public IActionResult Details(int id)
        {
            var customer = _customerRepo.GetCustomerById(id);
            return View(customer);
        }
    }
}
