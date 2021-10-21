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
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Hotelone19301408.Pages.Bookings
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
            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public IList<Room> Vacancy { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            //string _email = User.FindFirst(ClaimTypes.Name).Value;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");


            var parameter1 = new SqliteParameter("@Room", Booking.RoomID);
            var parameter2 = new SqliteParameter("@CheckI", Booking.CheckIn);
            var parameter3 = new SqliteParameter("@CheckO", Booking.CheckOut);
            string query = "SELECT * From Room Where ID = @Room AND ID NOT IN (SELECT RoomID FROM Booking WHERE (CheckIn <= @CheckI AND CheckOut >= @CheckO) OR (CheckIn < @CheckO AND CheckOut >=@CheckO) OR (@CheckI <= CheckIn AND @CheckO >= CheckIn))";
            Vacancy = await _context.Room.FromSqlRaw(query, parameter1, parameter2, parameter3).ToListAsync();

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
            bookingNew.Cost = nights * theRoom.Price;
            _context.Booking.Add(bookingNew);
            await _context.SaveChangesAsync();
                //context.Booking.Add(Booking);
                //await _context.SaveChangesAsync();
               
                ViewData["NewBooking"] = "true";
                ViewData["total"] = String.Format("{0:C}", bookingNew.Cost);
                ViewData["Rm"] = theRoom.ID;
                //ViewData["BedC"] = theRoom.BedCount;
                ViewData["NightCount"] = nights;
                ViewData["CustomerName"] = bookingNew.TheCustomer.FullName;
            }
            else
            {
                ViewData["NewBooking"] = "false";
            }
            return Page();
        }
    }
}


/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using Microsoft.Data.Sqlite;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace Hotelone19301408.Pages.Bookings
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
            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public IList<Room> Vacancy { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");


            var parameter1 = new SqliteParameter("@Room", Booking.RoomID);
            var parameter2 = new SqliteParameter("@CheckI", Booking.CheckIn);
            var parameter3 = new SqliteParameter("@CheckO", Booking.CheckOut);
            var parameter4 = new SqliteParameter("@Email", _email);
            //Tried to combine mine and Luke's queries
            /*
            string query = "SELECT [Room].* from [Room] inner join [Booking] on [Booking].RoomID= [Room].ID where [Room].Id = @roomID and " +
                " [Customer].Surname, [Customer].GivenName, [Booking].CheckIn, [Booking].CheckOut, [Booking].Cost FROM [Booking] "
            + "INNER JOIN [Customer] ON [Booking].CustomerEmail = [Customer].Email WHERE"
                + " [Customer].Email = @Email AND (CheckIn <= @CheckI AND CheckOut >= @CheckO) OR (CheckIn < @CheckO AND CheckOut >=@CheckO) OR (@CheckI <= CheckIn AND @CheckO >= CheckIn))";
            
            Vacancy = await _context.Room.FromSqlRaw(query, parameter1, parameter2, parameter3).ToListAsync();
string query = "SELECT * From Room Where ID = @Room AND ID NOT IN (SELECT RoomID FROM Booking WHERE (CheckIn <= @CheckI AND CheckOut >= @CheckO) OR (CheckIn < @CheckO AND CheckOut >=@CheckO) OR (@CheckI <= CheckIn AND @CheckO >= CheckIn))";
            Vacancy = await _context.Room.FromSqlRaw(query, parameter1, parameter2, parameter3).ToListAsync();
            int VacancyCount = Vacancy.Count();

            if (VacancyCount == 1)
            {
                Booking bookingNew = new Booking();
                bookingNew.CustomerEmail = _email;
                bookingNew.RoomID = Booking.RoomID;
                //Error here
                bookingNew.TheCustomer.GivenName = Booking.TheCustomer.GivenName;
                bookingNew.TheCustomer.Surname = Booking.TheCustomer.Surname;
                
                bookingNew.CheckIn = Booking.CheckIn;
                bookingNew.CheckOut = Booking.CheckOut;
                
                /*
                 *  CustomerEmail = _email,
                    RoomID = booking.RoomID,
                    GivenName = booking.TheCustomer.GivenName,
                    Surname = booking.TheCustomer.Surname,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    Cost = booking.Cost
                 *//*

                var theRoom = await _context.Room.FindAsync(Booking.RoomID);
                var nights = ((Booking.CheckOut - Booking.CheckIn).Days);
                bookingNew.Cost = nights * theRoom.Price;
                _context.Booking.Add(bookingNew);
                await _context.SaveChangesAsync();

                ViewData["NewBooking"] = "true";
                ViewData["total"] = String.Format("{0:C}", bookingNew.Cost);
                ViewData["Rm"] = theRoom.ID;
                ViewData["BedC"] = theRoom.BedCount;
                ViewData["NightCount"] = nights;
            }
            else
            {
                ViewData["NewBooking"] = "false";
            }


            return Page();
        }
    }
}
public async Task<IActionResult> OnPostAsync()
{
    if (!ModelState.IsValid)
    {
        return Page();
    }

    _context.Booking.Add(Booking);
    await _context.SaveChangesAsync();

    return RedirectToPage("./Index");
}
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotelone19301408.Data;
using Hotelone19301408.Models;
using Microsoft.Data.Sqlite;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace Hotelone19301408.Pages.Bookings
{
    [Authorize(Roles = "customers")]
    public class BookARoomModel : PageModel
    {
        private readonly Hotelone19301408.Data.ApplicationDbContext _context;

        public BookARoomModel(Hotelone19301408.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CEmail"] = new SelectList(_context.Customer, "Email", "Email");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public IList<Room> Vacancy { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");


            var parameter1 = new SqliteParameter("@Room", Booking.RoomID);
            var parameter2 = new SqliteParameter("@CheckI", Booking.CheckIn);
            var parameter3 = new SqliteParameter("@CheckO", Booking.CheckOut);
            string query = "SELECT * From Room Where ID = @Room AND ID NOT IN (SELECT RoomID FROM Booking WHERE (CheckIn <= @CheckI AND CheckOut >= @CheckO) OR (CheckIn < @CheckO AND CheckOut >=@CheckO) OR (@CheckI <= CheckIn AND @CheckO >= CheckIn))";
            Vacancy = await _context.Room.FromSqlRaw(query, parameter1, parameter2, parameter3).ToListAsync();

            int VacancyCount = Vacancy.Count();
            if (VacancyCount == 1)
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
                ViewData["total"] = String.Format("{0:C}", bookingNew.Cost);
                ViewData["Rm"] = theRoom.ID;
                ViewData["BedC"] = theRoom.BedCount;
                ViewData["NightCount"] = nights;
            }
            else
            {
                ViewData["NewBooking"] = "false";
            }


            return Page();
        }
    }
}

*/