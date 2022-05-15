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
        private readonly ICustomerRepository _context;
        public CustomerController(ICustomerRepository context)
        {
            _context = context;
        }



        //GET: Person/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var personDetail = await _context.GetCustomerByIdAsync(id);
            return View(personDetail);
        }

        //GET ALL PERSONS
        public async Task<IActionResult> List()
        {
            var personList = await _context.GetAllAsync();
            return View(personList);
        }


        //*******************************************************************************************

        //GET
        public IActionResult CreateCustomer()
        {

            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer newPerson)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(newPerson);
                return RedirectToAction("List");

            }
            return View(newPerson);
        }

        //********************************************************************************************

        // Först hämtar man personen sedan editerar man. Samma nedan i Delete

        //GET - EDIT
        public async Task<IActionResult> EditCustomer(int id)
        {
            
            var customerToDelete = await _context.GetByIdAsync(id);

            return View(customerToDelete);
        }

        //POST - EDIT
        [HttpPost]
        public async Task<IActionResult> EditCustomer(int id, [Bind("Id, Name, Phone, Email")] Customer person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            await _context.UpdateAsync(id, person);
            return RedirectToAction(nameof(List));

        }

        //********************************************************************************************

        //Först hämtar vi personen sedan deletar vi den

        //GET - DELETE
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            
            var personToDelete = await _context.GetByIdAsync(id);

            return View(personToDelete);
        }

        //POST - DELETE
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customerDetails = await _context.GetByIdAsync(id);
            if (customerDetails == null) return View("NotFound");
            await _context.DeleteAsync(id);

            return RedirectToAction("List");
        }

        //*************************************************************************

        //TEST SEARCH FUNCTIONALITY

        public async Task<IActionResult> Filter(string searchString)
        {
            var customerList = await _context.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = customerList.Where(n => n.Id.ToString() == searchString).ToList();
                return View("Search", filteredResult);
            }

            return View(customerList);
        }
    }
}
