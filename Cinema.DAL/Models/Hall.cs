using System.ComponentModel.DataAnnotations;

namespace Cinema.DAL.Models
{
    public class Hall
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }
    }
}
