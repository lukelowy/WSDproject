using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotelone19301408.Models
{
    public class ManageBookingsViewModel
    {
        [Display(Name = "Customer Email")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Display(Name = "Room ID")]
        [Range (1, 16)]
        public int RoomID { get; set; }
        
        [Required]
        [MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z'-]*$", ErrorMessage = "Please enter a valid last name with either letters, apostrophe or hyphen.")]
        public string Surname { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z'-]*$", ErrorMessage = "Please enter a valid last name with either letters, apostrophe or hyphen.")]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; }
       
        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => $"{GivenName} {Surname}";
        

        [DataType(DataType.Date)]
        [Display(Name = "Check In Date")]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Check Out Date")]
        public DateTime CheckOut { get; set; }


        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}
