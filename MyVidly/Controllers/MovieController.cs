using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MyVidly.Models;

namespace MyVidly.Controllers
{
    public class MovieController : Controller
    {
        public ApplicationDbContext ApplicationDbContext { get; set; }

        public MovieController()
        {
            ApplicationDbContext = new ApplicationDbContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = ApplicationDbContext.Movies.Include(z => z.Genre).ToList();
            return View(movies);
        }
        public ActionResult Edit(int id)
        {
            var movieFormViewModel = new MovieFormViewModel();
            movieFormViewModel.Movie = ApplicationDbContext.Movies.Include(z => z.Genre).SingleOrDefault(z => z.Id == id);
            movieFormViewModel.Genre = ApplicationDbContext.Genres.ToList();
            return View("MovieForm", movieFormViewModel);
        }
        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel();
            movieFormViewModel.Genre = ApplicationDbContext.Genres.ToList();
            return View("MovieForm", movieFormViewModel);
        }
        public ActionResult Submit(Movie movie)
        {
            if (movie.Id == 0)
            {
                ApplicationDbContext.Movies.Add(movie);
                ApplicationDbContext.SaveChanges();
            }
            else
            {
                var movieToUpdate = ApplicationDbContext.Movies.Single(z => z.Id == movie.Id);
                movieToUpdate.Name = movie.Name;
                movieToUpdate.NumberInStock = movie.NumberInStock;
                movieToUpdate.GenreId = movie.GenreId;
                movieToUpdate.ReleaseDate = movie.ReleaseDate;
                movieToUpdate.DateAdded = movie.DateAdded;
                ApplicationDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       
        //using ViewData
        public ActionResult Random()
        {
            var movie = new Movie
            {
                Name = "Pirte"
            };
            ViewBag.Mymovie = movie;
            return View();
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " " + month);

        }
    }
}