using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyVidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [DisplayName("Date Of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }

        [DisplayName("Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}