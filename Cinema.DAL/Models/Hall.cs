using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Models
{
    public class Hall
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }

        public IEnumerable<Movie> movies { get; set; }
    }
}
