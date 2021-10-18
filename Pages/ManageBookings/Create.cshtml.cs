using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;



namespace Hotelone19301408.Pages.ManageBookings
{
    public class CreateModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public CreateModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
        ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public TwoBookingDates DatesInput { get; set; }
        public IList<Booking> Vacancy { get; set; }
        public Booking Booking { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string _email = User.FindFirst(ClaimTypes.Name).Value;

            var parameter1 = new SqliteParameter("@Room", DatesInput.RoomID);
            var parameter2 = new SqliteParameter("@CheckI", DatesInput.CheckIn);
            var parameter3 = new SqliteParameter("@CheckO", DatesInput.CheckOut);
            //Construct query
            //I need to see if a room has already been booked
            //SQL From the DB Lite test
            /*SELECT Booking.RoomID, Customer.Surname, Customer.GivenName, CheckIn, CheckOut, Cost FROM 
             * Booking INNER JOIN Customer ON Booking.CustomerEmail = Customer.Email 
               WHERE RoomID = 1 AND CheckIn BETWEEN '2021-09-06 00:00:00' AND '2021-09-10 00:00:00'*/
            //string query = "SELECT [Booking].RoomID, [Customer].Surname, [Customer].GivenName, [Booking].CheckIn, [Booking].CheckOut, [Booking].Cost FROM [Booking] "
            //   + "INNER JOIN [Customer] ON [Booking].CustomerEmail = [Customer].Email WHERE [Booking].RoomID = @Room AND [Booking].CheckIn BETWEEN @CheckI AND @CheckO)";

            var vacancy = _context.Booking.FromSqlRaw("SELECT [Booking].RoomID, [Customer].Surname, [Customer].GivenName, [Booking].CheckIn, [Booking].CheckOut, [Booking].Cost FROM [Booking] "
                + "INNER JOIN [Customer] ON [Booking].CustomerEmail = [Customer].Email WHERE [Booking].RoomID = @Room AND [Booking].CheckIn BETWEEN @CheckI AND @CheckO)", parameter1, parameter2, parameter3);
            Vacancy = await vacancy.ToListAsync();
            //Count how many entries there are
            int VacancyCount = Vacancy.Count();
            //If there are no entries, then there will be a new booking entry
            if (VacancyCount == 0)
            {
                Booking bookingNew = new Booking();
                bookingNew.CheckIn = Booking.CheckIn;
                bookingNew.CheckOut = Booking.CheckOut;
                bookingNew.RoomID = Booking.RoomID;
                bookingNew.CustomerEmail = _email;


                var theRoom = await _context.Room.FindAsync(Booking.RoomID);
                var nights = ((Booking.CheckOut - Booking.CheckIn).Days);
                bookingNew.Cost = nights * theRoom.Price;
                _context.Booking.Add(bookingNew);
                await _context.SaveChangesAsync();

                ViewData["NewBooking"] = "true";
                ViewData["total"] = bookingNew.Cost;
                ViewData["Rm"] = theRoom.ID;
                ViewData["BedC"] = theRoom.BedCount;
                ViewData["NightCount"] = nights;

                ViewData["ChkIn"] = bookingNew.CheckIn;
                ViewData["ChkOut"] = bookingNew.CheckOut;
                
            }
            else
            {
                ViewData["NewBooking"] = "false";
            }
               
            
            return Page();
            // _context.Booking.Add(Booking); 
           //await _context.SaveChangesAsync();
           

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
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;



namespace Hotelone19301408.Pages.ManageBookings
{
    [Authorize(Roles = "administrators")]
    public class CreateModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public CreateModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "Email");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Level");
            return Page();
        }

        [BindProperty]
        public ManageBookingsViewModel ManageBookings { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            //because the webform involves using both Customer and Booking it is necessary to do this
            //Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);
            Booking booking = await _context.Booking.FirstOrDefaultAsync(b => b.CustomerEmail == _email);

            if (booking != null)
            {
                ViewData["ExistInDB"] = "true";
                ManageBookings = new ManageBookingsViewModel
                {
                    RoomID = booking.RoomID,
                    Surname = booking.TheCustomer.Surname,
                    GivenName = booking.TheCustomer.GivenName,
                    //FullName = customer.FullName,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    Cost = booking.Cost,
                };
            }
            else
            {
                ViewData["ExistInDB"] = "fasle";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            //Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);
            Booking booking = await _context.Booking.FirstOrDefaultAsync(b => b.CustomerEmail == _email);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            booking.TheCustomer.Email = _email;
            booking.TheCustomer.GivenName = ManageBookings.GivenName;
            booking.TheCustomer.Surname = ManageBookings.Surname;
            booking.RoomID = ManageBookings.RoomID;
            booking.CheckIn = ManageBookings.CheckIn;
            booking.CheckOut = ManageBookings.CheckOut;
            booking.Cost = ManageBookings.Cost;

            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}*/
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;



namespace Hotelone19301408.Pages.ManageBookings
{
    [Authorize(Roles = "administrators")]
    public class CreateModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public CreateModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public ManageBookingsViewModel ManageBookings { get; set; }
        public IList<Booking> DiffBookings { get; set; }
        public IActionResult OnGet()
        {
            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Level");
            string _email = User.FindFirst(ClaimTypes.Name).Value;
          
                ManageBookings = new ManageBookingsViewModel
                {
                    RoomID = booking.RoomID,
                    Surname = booking.TheCustomer.Surname,
                    GivenName = booking.TheCustomer.GivenName,
                    //FullName = customer.FullName,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    Cost = booking.Cost,
                };
            }
            else
            {
                ViewData["ExistInDB"] = "fasle";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            //Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);
            Booking booking = await _context.Booking.FirstOrDefaultAsync(b => b.CustomerEmail == _email);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            booking.TheCustomer.Email = _email;
            booking.TheCustomer.GivenName = ManageBookings.GivenName;
            booking.TheCustomer.Surname = ManageBookings.Surname;
            booking.RoomID = ManageBookings.RoomID;
            booking.CheckIn = ManageBookings.CheckIn;
            booking.CheckOut = ManageBookings.CheckOut;
            booking.Cost = ManageBookings.Cost;

            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
*/