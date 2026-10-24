using Cinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Customers
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        int SaveChanges();
    }
}
