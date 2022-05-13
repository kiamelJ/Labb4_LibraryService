using Labb4_LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Interfaces
{
    public interface ICustomerRepository
    {
        //Man kan alltså skriva så här också?
        //Jag är ju van att skriva GetAllCustomers();
        IEnumerable<Customer> GetAllCustomers { get; }
        Customer GetCustomerById(int id);
        Customer CreateCustomer(Customer newCustomer);
        void DeleteCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);

        IEnumerable<Customer> Search(string name);
    }
}
