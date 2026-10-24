using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BL.DTOs.Halls
{
    public class HallWriteDTO
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }
    }
}
