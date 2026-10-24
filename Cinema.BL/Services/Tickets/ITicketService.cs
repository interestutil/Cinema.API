using System.Collections.Generic;
using Cinema.BL.DTOs.Tickets;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Tickets;

namespace Cinema.BL.Services.Tickets
{
    public interface ITicketService
    {
        IEnumerable<TicketReadDTO> GetAllTickets();
        TicketReadDTO? GetTicketById(int id);
        TicketReadDTO AddTicket(TicketWriteDTO ticketDto);
        TicketReadDTO? UpdateTicket(int id, TicketWriteDTO ticketDto);
        bool DeleteTicket(int id);
    }
}
