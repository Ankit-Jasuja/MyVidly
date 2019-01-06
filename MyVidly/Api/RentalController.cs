using System.Web.Http;
using MyVidly.Models;

namespace MyVidly.Api
{
    public class RentalController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalModel newRentalModel)
        {
            return Ok();
        }
    }
}
