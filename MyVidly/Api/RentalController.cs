using System;
using System.Linq;
using System.Web.Http;
using MyVidly.Models;

namespace MyVidly.Api
{
    public class RentalController : ApiController
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RentalController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalModel newRentalModel)
        {
            foreach (var movieId in newRentalModel.MovieIdList)
            {
                var movie = _applicationDbContext.Movies.ToList().Single(m => m.Id == movieId);
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    DateRented = DateTime.Today,
                    Customer = _applicationDbContext.Customers.ToList().Single(m => m.Id == newRentalModel.CustomerId),
                    Movie = movie
                };
                _applicationDbContext.Rentals.Add(rental);
            }
            _applicationDbContext.SaveChanges();
            return Ok();
        }
    }
}
