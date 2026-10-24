using System.Collections.Generic;
using Cinema.BL.DTOs.Customers;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Customers;

namespace Cinema.BL.Services.Customers
{
    public interface ICustomerService
    {
        IEnumerable<CustomerReadDTO> GetAllCustomers();
        CustomerReadDTO? GetCustomerById(int id);
        CustomerReadDTO AddCustomer(CustomerWriteDTO customerDto);
        CustomerReadDTO? UpdateCustomer(int id, CustomerWriteDTO customerDto);
        bool DeleteCustomer(int id);
    }
}
