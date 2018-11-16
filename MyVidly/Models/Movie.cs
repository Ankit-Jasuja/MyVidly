using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyVidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Addded Date")]
        public DateTime DateAdded { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        [DisplayName("Number In Stock")]
        [Required]
        public byte NumberInStock { get; set; }
    }
}