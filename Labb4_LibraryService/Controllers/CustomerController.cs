using Labb4_LibraryService.Interfaces;
using Labb4_LibraryService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Controllers
{
    public class CustomerController : Controller
    {
        
        private readonly ICustomerRepository _context;
        public CustomerController(ICustomerRepository context)
        {
            _context = context;
        }


        
        public async Task<IActionResult> List()
        {
            var personList = await _context.GetAllAsync();
            return View(personList);
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var personDetail = await _context.GetCustomerByIdAsync(id);
            return View(personDetail);
        }


        public IActionResult CreateCustomer()
        {

            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([Bind("Id, Name, Phone, Email")]Customer newPerson)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(newPerson);
                return RedirectToAction("List");

            }
            return View(newPerson);
        }

        
        public async Task<IActionResult> EditCustomer(int id)
        {
            
            var customerToDelete = await _context.GetByIdAsync(id);

            return View(customerToDelete);
        }

        
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

        
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            
            var personToDelete = await _context.GetByIdAsync(id);

            return View(personToDelete);
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customerDetails = await _context.GetByIdAsync(id);
            if (customerDetails == null) return View("NotFound");
            await _context.DeleteAsync(id);

            return RedirectToAction("List");
        }


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
