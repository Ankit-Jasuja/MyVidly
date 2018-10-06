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
        public ActionResult Details(int id)
        {
            var movie = ApplicationDbContext.Movies.Include(z => z.Genre).SingleOrDefault(z => z.Id == id);
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