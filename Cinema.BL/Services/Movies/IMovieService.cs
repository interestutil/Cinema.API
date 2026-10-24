using System.Collections.Generic;
using Cinema.BL.DTOs.Movies;

namespace Cinema.BL.Services.Movies
{
    public interface IMovieService
    {
        IEnumerable<ReadMovieDTO> GetAllMovies();
        ReadMovieDTO? GetMovieById(int id);
        ReadMovieDTO AddMovie(WriteMovieDTO movieDto);
        ReadMovieDTO? UpdateMovie(int id, WriteMovieDTO movieDto);
        bool DeleteMovie(int id);
    }
}
