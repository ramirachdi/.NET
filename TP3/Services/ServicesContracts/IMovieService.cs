using TP3.Models;

namespace TP3.Services.ServicesContracts
{
    public interface IMovieService
    {

      public  List<Movie> getMoviesByGenreName(string genre);
        public List<Movie> getMoviesOrderedByName();

        public List<Movie> getMoviesByGenreID(int id);

    }
}
