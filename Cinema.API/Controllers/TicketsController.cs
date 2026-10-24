using System.Collections.Generic;
using Cinema.BL.DTOs.Tickets;
using Cinema.BL.Services.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TicketReadDTO>> GetAllTickets()
        {
            return Ok(_ticketService.GetAllTickets());
        }

        [HttpGet("{id:int}")]
        public ActionResult<TicketReadDTO> GetTicketById(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            return ticket == null ? NotFound() : Ok(ticket);
        }

        [HttpPost]
        public ActionResult<TicketReadDTO> CreateTicket([FromBody] TicketWriteDTO ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTicket = _ticketService.AddTicket(ticketDto);
            return CreatedAtAction(nameof(GetTicketById), new { id = createdTicket.Id }, createdTicket);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TicketReadDTO> UpdateTicket(int id, [FromBody] TicketWriteDTO ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTicket = _ticketService.UpdateTicket(id, ticketDto);
            return updatedTicket == null ? NotFound() : Ok(updatedTicket);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTicket(int id)
        {
            var deleted = _ticketService.DeleteTicket(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
