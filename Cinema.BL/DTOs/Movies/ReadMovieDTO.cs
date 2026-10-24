using Cinema.BL.DTOs.Halls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BL.DTOs.Movies
{
    public class ReadMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public HallReadDTO hall { get; set; }
    }
}
