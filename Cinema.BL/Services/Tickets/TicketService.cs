using System.Collections.Generic;
using System.Linq;
using Cinema.BL.DTOs.Tickets;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Tickets;

namespace Cinema.BL.Services.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketService(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public IEnumerable<TicketReadDTO> GetAllTickets()
        {
            return _ticketRepo.GetTickets()
                .Select(MapToReadDto)
                .ToList();
        }

        public TicketReadDTO? GetTicketById(int id)
        {
            var ticket = _ticketRepo.GetTicket(id);
            return ticket == null ? null : MapToReadDto(ticket);
        }

        public TicketReadDTO AddTicket(TicketWriteDTO ticketDto)
        {
            var ticket = new Ticket
            {
                SeatNumber = ticketDto.SeatNumber,
                Price = ticketDto.Price,
                ShowTime = ticketDto.ShowTime,
                CustomerId = ticketDto.CustomerId
            };

            _ticketRepo.AddTicket(ticket);
            _ticketRepo.SaveChanges();

            return MapToReadDto(ticket);
        }

        public TicketReadDTO? UpdateTicket(int id, TicketWriteDTO ticketDto)
        {
            var existingTicket = _ticketRepo.GetTicket(id);
            if (existingTicket == null)
            {
                return null;
            }

            existingTicket.SeatNumber = ticketDto.SeatNumber;
            existingTicket.Price = ticketDto.Price;
            existingTicket.ShowTime = ticketDto.ShowTime;
            existingTicket.CustomerId = ticketDto.CustomerId;

            _ticketRepo.UpdateTicket(existingTicket);
            _ticketRepo.SaveChanges();

            return MapToReadDto(existingTicket);
        }

        public bool DeleteTicket(int id)
        {
            var existingTicket = _ticketRepo.GetTicket(id);
            if (existingTicket == null)
            {
                return false;
            }

            _ticketRepo.DeleteTicket(id);
            _ticketRepo.SaveChanges();
            return true;
        }

        private static TicketReadDTO MapToReadDto(Ticket ticket)
        {
            return new TicketReadDTO
            {
                Id = ticket.Id,
                SeatNumber = ticket.SeatNumber,
                Price = ticket.Price,
                ShowTime = ticket.ShowTime,
                CustomerId = ticket.CustomerId
            };
        }
    }
}
