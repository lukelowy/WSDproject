using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using Microsoft.AspNetCore.Authorization;


namespace Hotelone19301408.Pages.ManageBookings
{
    [Authorize (Roles = "administrators")]
    public class IndexModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public IndexModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            //I do not think I shoud use a .inlcude() because the roomID is already in the class 
            Booking = await _context.Booking
                .Include(b => b.TheCustomer.Surname).Include(b => b.TheCustomer.GivenName).ToListAsync();
                //.Include(b => b.RoomID).ToListAsync();
        }
    }
}
