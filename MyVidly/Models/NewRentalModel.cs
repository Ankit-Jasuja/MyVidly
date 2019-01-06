using System.Collections.Generic;

namespace MyVidly.Models
{
    public class NewRentalModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}