using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Hotelone19301408.Models
{
    public class TwoBookingDates
    {
        [Required]
        [Range(1,16)]
        [Display(Name = "Room ID")]
        public int RoomID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Check In Date")]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Check In Date")]
        public DateTime CheckOut { get; set; }
    }
}
