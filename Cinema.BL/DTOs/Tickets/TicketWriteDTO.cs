using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.BL.DTOs.Tickets
{
    public class TicketWriteDTO
    {
        [Required(ErrorMessage = "Seat number is required")]
        [StringLength(20, ErrorMessage = "Seat number cannot exceed 20 characters")]
        public string SeatNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Show time is required")]
        public DateTime ShowTime { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerId must be greater than zero")]
        public int CustomerId { get; set; }
    }
}
