using System.Collections.Generic;
using System.Web.Mvc;
using MyVidly.Models;

namespace MyVidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie> { new Movie() { Id = 1, Name = "Shark" }, new Movie() { Id = 5, Name = "Dolphin" } };
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