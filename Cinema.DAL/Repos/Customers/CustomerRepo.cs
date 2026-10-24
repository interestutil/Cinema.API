using Cinema.DAL.Data;
using Cinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Customers
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationContext _applicationContext;

        public CustomerRepo(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void AddCustomer(Customer customer)
        {
            _applicationContext.Customers.Add(customer);
        }   

        public void DeleteCustomer(int id)
        {
            _applicationContext.Customers.Remove(_applicationContext.Customers.Find(id));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _applicationContext.Customers;
        }

        public Customer GetCustomer(int id)
        {
            return _applicationContext.Customers.Find(id);
        }

        public int SaveChanges()
        {
            return _applicationContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
