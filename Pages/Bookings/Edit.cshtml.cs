using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Authorization;

namespace Hotelone19301408.Pages.Bookings
{
    [Authorize(Roles = "administrators")]
    public class EditModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public EditModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public IList<Room> Vacancy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking
                .Include(b => b.TheCustomer)
                .Include(b => b.TheRoom).FirstOrDefaultAsync(m => m.ID == id);

            if (Booking == null)
            {
                return NotFound();
            }
            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID", "ID");

            //The greatest breakthrough ever
            //these two lines basically  remove the entry of the row that is being edited therefore preventing any data duplcation
            _context.Booking.Remove(Booking);
            await _context.SaveChangesAsync();
            //I also realised that there is no 'update' command or phrase that the .NET framecore has to update except for '.add'
            //so it would make sese to remove the entry and add it back. In a nutshell this page is basically a combination of the function of the
            //Delete.html page but basically is a Create.html but the fields have already been entered
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //make sure the content in the dropdown lists stays 
            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID", "ID");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Brought back the SQL used from the create page
            var parameter1 = new SqliteParameter("@Room", Booking.RoomID);
            var parameter2 = new SqliteParameter("@CheckI", Booking.CheckIn);
            var parameter3 = new SqliteParameter("@CheckO", Booking.CheckOut);
            string query = "SELECT * From Room Where ID = @Room AND ID NOT IN (SELECT RoomID FROM Booking WHERE (CheckIn <= @CheckI AND CheckOut >= @CheckO) OR (CheckIn < @CheckO AND CheckOut >=@CheckO) OR (@CheckI <= CheckIn AND @CheckO >= CheckIn))";
            Vacancy = await _context.Room.FromSqlRaw(query, parameter1, parameter2, parameter3).ToListAsync();
            _context.Attach(Booking).State = EntityState.Modified;

            int VacancyCount = Vacancy.Count();
            if (VacancyCount == 1)
            {
                Booking bookingNew = new Booking();
                bookingNew.CheckIn = Booking.CheckIn;
                bookingNew.CheckOut = Booking.CheckOut;
                bookingNew.RoomID = Booking.RoomID;

                var theCustomer = await _context.Customer.FindAsync(Booking.CustomerEmail);
                bookingNew.TheCustomer = theCustomer;



                var theRoom = await _context.Room.FindAsync(Booking.RoomID);
                var nights = ((Booking.CheckOut - Booking.CheckIn).Days);
                bookingNew.Cost = Booking.Cost;
                //_context.Booking.Add(bookingNew);
                //Commented these lines of code because it is basically used under the try statement
                //await _context.SaveChangesAsync();
                _context.Booking.Add(Booking);
                await _context.SaveChangesAsync();

                ViewData["NewBooking"] = "true";
                ViewData["total"] = String.Format("{0:C}", bookingNew.Cost);
                ViewData["Rm"] = theRoom.ID;
                //ViewData["BedC"] = theRoom.BedCount;
                ViewData["NightCount"] = nights;
                ViewData["CustomerName"] = bookingNew.TheCustomer.FullName;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(Booking.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;

                    }
                }

            }
            else
            {
                ViewData["NewBooking"] = "false";
            }

            
            return Page();
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID == id);
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotelone19301408.Data;
using Hotelone19301408.Models;

namespace Hotelone19301408.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public EditModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking
                .Include(b => b.TheCustomer)
                .Include(b => b.TheRoom).FirstOrDefaultAsync(m => m.ID == id);

            if (Booking == null)
            {
                return NotFound();
            }
           ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "Email");
           ViewData["RoomID"] = new SelectList(_context.Set<Room>(), "ID", "Level");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID == id);
        }
    }
}
*/