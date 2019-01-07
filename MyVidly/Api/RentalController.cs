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
            var customer = _applicationDbContext.Customers.ToList().Single(m => m.Id == newRentalModel.CustomerId);

            var moviesInDb = _applicationDbContext.Movies.Where(z => newRentalModel.MovieIdList.Contains(z.Id))
                .ToList();

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
