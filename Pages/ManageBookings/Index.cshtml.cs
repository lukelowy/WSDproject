using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Data;
using Hotelone19301408.Models;

namespace Hotelone19301408.Pages.ManageBookings
{
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
            Booking = await _context.Booking
                .Include(b => b.TheCustomer)
                .Include(b => b.TheRoom).ToListAsync();
        }
    }
}
/*
 *  public IList<Booking> ManageBookings { get;set; }

        public async Task OnGetAsync()
        {
            //SQL expression SELECT RoomID, Customer.Surname, Customer.GivenName, CheckIn, CheckOut, Cost FROM Booking INNER JOIN Customer WHERE Booking.CustomerEmail = Customer.Email
            var managebookings = _context.Booking.FromSqlRaw("SELECT RoomID, [Customer].Surname, [Customer].GivenName, CheckIn, CheckOut, Cost FROM [Booking]"
                + "INNER JOIN [Customer] WHERE [Booking].CustomerEmail = [Customer].Email");

            // Run the query and save the results in ManageBookings for passing to content file
            ManageBookings = await managebookings.ToListAsync();
        }
 */