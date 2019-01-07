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
            if (!newRentalModel.MovieIdList.Any())
            {
                return BadRequest("Movie Id list is empty");
            }

            var customer = _applicationDbContext.Customers.ToList().SingleOrDefault(m => m.Id == newRentalModel.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer id is Invalid");
            }

            var moviesInDb = _applicationDbContext.Movies.Where(z => newRentalModel.MovieIdList.Contains(z.Id))
                .ToList();

            if (moviesInDb.Count != newRentalModel.MovieIdList.Count())
            {
                return BadRequest("one or more movie id is invalid");
            }

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    DateRented = DateTime.Today,
                    Customer = customer,
                    Movie = movie
                };
                _applicationDbContext.Rentals.Add(rental);
            }
            _applicationDbContext.SaveChanges();
            return Ok();
        }
    }
}
