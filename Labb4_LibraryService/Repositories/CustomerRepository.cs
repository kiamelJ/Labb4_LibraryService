using Labb4_LibraryService.Interfaces;
using Labb4_LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LibDbContext _libContext;
        public CustomerRepository(LibDbContext libContext)
        {
            _libContext = libContext;
        }
        
        public IEnumerable<Customer> GetAllCustomers
        {
            get
            {
                return _libContext.Customers.ToList();
            }
        }

        public Customer CreateCustomer(Customer newCustomer)
        {
            _libContext.Customers.Add(newCustomer);
            _libContext.SaveChanges();
            return newCustomer;
        }

        public void DeleteCustomer(Customer customer)
        {
            _libContext.Customers.Remove(customer);
            _libContext.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            return _libContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var existingCustomer = _libContext.Customers.Find(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Email = customer.Email;

                _libContext.Customers.Update(existingCustomer);
                _libContext.SaveChanges();
            }
            return customer;
        }
    }
}
