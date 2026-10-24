using System.Collections.Generic;
using Cinema.BL.DTOs.Movies;
using Cinema.BL.Services.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadMovieDTO>> GetAllMovies()
        {
            return Ok(_movieService.GetAllMovies());
        }

        [HttpGet("{id:int}")]
        public ActionResult<ReadMovieDTO> GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public ActionResult<ReadMovieDTO> CreateMovie([FromBody] WriteMovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdMovie = _movieService.AddMovie(movieDto);
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ReadMovieDTO> UpdateMovie(int id, [FromBody] WriteMovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedMovie = _movieService.UpdateMovie(id, movieDto);
            return updatedMovie == null ? NotFound() : Ok(updatedMovie);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteMovie(int id)
        {
            var deleted = _movieService.DeleteMovie(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
