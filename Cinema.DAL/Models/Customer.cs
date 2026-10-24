using System.ComponentModel.DataAnnotations;

namespace Cinema.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}
