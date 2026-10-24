using System.Collections.Generic;
using System.Linq;
using Cinema.BL.DTOs.Halls;
using Cinema.BL.DTOs.Movies;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Movies;

namespace Cinema.BL.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _movieRepo;

        public MovieService(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public IEnumerable<ReadMovieDTO> GetAllMovies()
        {
            return _movieRepo.GetMovies()
                .Select(MapToReadDto)
                .ToList();
        }

        public ReadMovieDTO? GetMovieById(int id)
        {
            var movie = _movieRepo.GetMovie(id);
            return movie == null ? null : MapToReadDto(movie);
        }

        public ReadMovieDTO AddMovie(WriteMovieDTO movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Duration = movieDto.Duration,
                HallId = movieDto.HallId
            };

            _movieRepo.AddMovie(movie);
            _movieRepo.SaveChanges();

            return MapToReadDto(movie);
        }

        public ReadMovieDTO? UpdateMovie(int id, WriteMovieDTO movieDto)
        {
            var existingMovie = _movieRepo.GetMovie(id);
            if (existingMovie == null)
            {
                return null;
            }

            existingMovie.Title = movieDto.Title;
            existingMovie.Duration = movieDto.Duration;
            existingMovie.HallId = movieDto.HallId;

            _movieRepo.UpdateMovie(existingMovie);
            _movieRepo.SaveChanges();

            return MapToReadDto(existingMovie);
        }

        public bool DeleteMovie(int id)
        {
            var existingMovie = _movieRepo.GetMovie(id);
            if (existingMovie == null)
            {
                return false;
            }

            _movieRepo.DeleteMovie(id);
            _movieRepo.SaveChanges();
            return true;
        }

        private static ReadMovieDTO MapToReadDto(Movie movie)
        {
            return new ReadMovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                hall = movie.Hall == null ? null : new HallReadDTO
                {
                    Id = movie.Hall.Id,
                    Name = movie.Hall.Name,
                    Capacity = movie.Hall.Capacity
                }
            };
        }
    }
}
