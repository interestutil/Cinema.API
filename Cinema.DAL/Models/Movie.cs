using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }
        public int HallId { get; set; }

        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; }
        public IEnumerable<Customer> customers { get; set; }
    }
}
