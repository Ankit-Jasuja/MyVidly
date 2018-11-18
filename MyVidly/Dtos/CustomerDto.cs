using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyVidly.Models;

namespace MyVidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public DateTime? BirthDate { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}