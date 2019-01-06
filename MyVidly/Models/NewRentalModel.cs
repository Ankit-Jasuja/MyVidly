using System.Collections.Generic;

namespace MyVidly.Models
{
    public class NewRentalModel
    {
        public int CustomerId { get; set; }
        public IEnumerable<int> MovieIdList { get; set; }
    }
}