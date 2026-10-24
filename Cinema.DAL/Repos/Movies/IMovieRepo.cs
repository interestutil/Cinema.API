using Cinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Movies
{
    public interface IMovieRepo
    {
        IEnumerable<Models.Movie> GetMovies();
        Models.Movie GetMovie(int id);
        void AddMovie(Models.Movie movie);
        void UpdateMovie(Models.Movie movie);
        void DeleteMovie(int id);
        int SaveChanges();

    }
}
