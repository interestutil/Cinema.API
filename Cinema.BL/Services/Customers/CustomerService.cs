using System.Collections.Generic;
using System.Linq;
using Cinema.BL.DTOs.Customers;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Customers;

namespace Cinema.BL.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IEnumerable<CustomerReadDTO> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers()
                .Select(MapToReadDto)
                .ToList();
        }

        public CustomerReadDTO? GetCustomerById(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            return customer == null ? null : MapToReadDto(customer);
        }

        public CustomerReadDTO AddCustomer(CustomerWriteDTO customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                TicketId = 0
            };

            _customerRepo.AddCustomer(customer);
            _customerRepo.SaveChanges();

            return MapToReadDto(customer);
        }

        public CustomerReadDTO? UpdateCustomer(int id, CustomerWriteDTO customerDto)
        {
            var existingCustomer = _customerRepo.GetCustomer(id);
            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Name = customerDto.Name;
            existingCustomer.Email = customerDto.Email;

            _customerRepo.UpdateCustomer(existingCustomer);
            _customerRepo.SaveChanges();

            return MapToReadDto(existingCustomer);
        }

        public bool DeleteCustomer(int id)
        {
            var existingCustomer = _customerRepo.GetCustomer(id);
            if (existingCustomer == null)
            {
                return false;
            }

            _customerRepo.DeleteCustomer(id);
            _customerRepo.SaveChanges();
            return true;
        }

        private static CustomerReadDTO MapToReadDto(Customer customer)
        {
            return new CustomerReadDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email ?? string.Empty
            };
        }
    }
}
