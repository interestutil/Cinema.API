using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string SeatNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime ShowTime { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

    }
}
