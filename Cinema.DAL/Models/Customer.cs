using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        public int TicketId { get; set; }

        public IEnumerable<Movie> movies { get; set; }
        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; }
    }
}
