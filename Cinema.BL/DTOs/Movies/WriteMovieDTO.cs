using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BL.DTOs.Movies
{
    public class WriteMovieDTO
    {
        [Required(ErrorMessage = "Title is required"), MaxLength(150)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "HallId is required")]
        public int HallId { get; set; }
    }
}
