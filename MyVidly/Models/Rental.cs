using System;
using System.ComponentModel.DataAnnotations;

namespace MyVidly.Models
{
    public class Rental
    {
        public byte Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Movie Movie { get; set; }
    }
}