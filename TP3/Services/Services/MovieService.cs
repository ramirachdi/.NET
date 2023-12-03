using Humanizer.Localisation;
using TP3.Models;
using TP3.Services.ServicesContracts;

namespace TP3.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _db;
        public MovieService(AppDbContext db) {
            _db = db;

        }


        public List<Movie> getMoviesByGenreName(string genre)
        {
            var queue = _db.Movies
                .Where(q => q.Genres.GenreName == genre)
                .ToList();
            return queue;

        }
        public List<Movie> getMoviesOrderedByName()
        {
            var queue = _db.Movies
              .OrderBy(q => q.Name)
              .ToList();
            return queue;

        }

        public List<Movie> getMoviesByGenreID(int id)
        {
            var queue = _db.Movies
         .Where(q =>  q.genre_id.ToString() == id.ToString())
         .ToList();
            return queue;

        }

    }
}
