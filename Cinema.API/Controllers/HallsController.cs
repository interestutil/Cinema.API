using System.Collections.Generic;
using Cinema.BL.DTOs.Halls;
using Cinema.BL.Services.Halls;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallsController : ControllerBase
    {
        private readonly IHallService _hallService;

        public HallsController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HallReadDTO>> GetAllHalls()
        {
            return Ok(_hallService.GetAllHalls());
        }

        [HttpGet("{id:int}")]
        public ActionResult<HallReadDTO> GetHallById(int id)
        {
            var hall = _hallService.GetHallById(id);
            return hall == null ? NotFound() : Ok(hall);
        }

        [HttpPost]
        public ActionResult<HallReadDTO> CreateHall([FromBody] HallWriteDTO hallDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdHall = _hallService.AddHall(hallDto);
            return CreatedAtAction(nameof(GetHallById), new { id = createdHall.Id }, createdHall);
        }

        [HttpPut("{id:int}")]
        public ActionResult<HallReadDTO> UpdateHall(int id, [FromBody] HallWriteDTO hallDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedHall = _hallService.UpdateHall(id, hallDto);
            return updatedHall == null ? NotFound() : Ok(updatedHall);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteHall(int id)
        {
            var deleted = _hallService.DeleteHall(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
