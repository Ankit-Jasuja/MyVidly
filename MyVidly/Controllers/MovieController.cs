using System.Web.Mvc;
using MyVidly.Models;

namespace MyVidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movie = new Movie
            {
                Name = "Pirte"
            };
            return View(movie);
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