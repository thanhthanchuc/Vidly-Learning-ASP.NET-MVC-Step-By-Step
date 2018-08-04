using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Models.CustomValidationAttribute;

namespace Vidly.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This feld can not be null.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Supprier to new Letter?")]
        public bool IsSuprierToNewLetter { get; set; }

        [Required(ErrorMessage = "Please chose a membership type.")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Is18YearOldIfIsMember]
        public DateTime? BirthDay { get; set; }
    }
}