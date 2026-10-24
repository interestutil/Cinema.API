using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Duration { get; set; }

        public int HallId { get; set; }

        [ForeignKey(nameof(HallId))]
        public Hall? Hall { get; set; }
    }
}
