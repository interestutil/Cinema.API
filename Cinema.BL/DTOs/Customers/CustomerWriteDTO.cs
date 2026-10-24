using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BL.DTOs.Customers
{
    public class CustomerWriteDTO
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

    }
}
