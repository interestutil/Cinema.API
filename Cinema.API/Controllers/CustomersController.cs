using System.Collections.Generic;
using Cinema.BL.DTOs.Customers;
using Cinema.BL.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDTO>> GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet("{id:int}")]
        public ActionResult<CustomerReadDTO> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public ActionResult<CustomerReadDTO> CreateCustomer([FromBody] CustomerWriteDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCustomer = _customerService.AddCustomer(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CustomerReadDTO> UpdateCustomer(int id, [FromBody] CustomerWriteDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCustomer = _customerService.UpdateCustomer(id, customerDto);
            return updatedCustomer == null ? NotFound() : Ok(updatedCustomer);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            var deleted = _customerService.DeleteCustomer(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
