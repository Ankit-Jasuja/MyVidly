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
    }
}