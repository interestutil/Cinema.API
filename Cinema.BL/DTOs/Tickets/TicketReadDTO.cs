using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.BL.DTOs.Tickets
{
    public class TicketReadDTO
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ShowTime { get; set; }
        public int CustomerId { get; set; }
    }
}
