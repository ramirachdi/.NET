using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _db;

        public MovieController(AppDbContext db)
        { _db = db; }
        // GET: MovieController
        public IActionResult Index()
        {
            if (_db.Movies != null)
            {
                var movies = _db.Movies.ToList();
                return View(movies);
            }
            else { return View(); }
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public IActionResult Create()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
           
            movie.Id = new Guid();
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _db.Movies
                .Include(m => m.Genres)
                .Include(m => m.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,MovieAdded,genre_id")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the movie entity in the database
                    _db.Update(movie);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to the action of your choice
            }

            return View(movie);
        }

        private bool MovieExists(Guid id)
        {
            return _db.Movies.Any(e => e.Id == id);
        }

        public IActionResult Delete(Guid id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movie = _db.Movies.Find(id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




        [HttpGet("/Movie/Details/{MovieId}")]
        public IActionResult Details(String MovieId)
        {
            var movie = _db.Movies.ToList().SingleOrDefault(c => c.Id.ToString() == MovieId);
            if (movie == null)
            {
                return (Content("Error 404 : Movie " + MovieId + " not found"));
            }
            return (View(movie));
        }
    }
}
