using Cinema.DAL.Data;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Movies
{
    public class MovieRepo : IMovieRepo
    {
        private readonly ApplicationContext _applicationContext;

        public MovieRepo(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void AddMovie(Movie movie)
        {
            _applicationContext.Movies.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            _applicationContext.Movies.Remove(_applicationContext.Movies.Find(id));
        }

        public Movie GetMovie(int id)
        {
            return _applicationContext.Movies.Find(id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _applicationContext.Movies.ToList();
        }

        public int SaveChanges()
        {
            return _applicationContext.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _applicationContext.Movies.Update(movie);
        }
    }
}
