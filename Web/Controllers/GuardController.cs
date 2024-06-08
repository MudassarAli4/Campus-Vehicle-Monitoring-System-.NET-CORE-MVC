//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Web.Models;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Web.Controllers
//{
//    public class GuardController : Controller
//    {
//        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

//        public GuardController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index(string query)
//        {
//            var inOuts = _context.InOuts
//                                 .Include(i => i.Vehicle)
//                                 .AsQueryable();

//            if (!string.IsNullOrEmpty(query))
//            {
//                inOuts = inOuts.Where(i => i.Vehicle.Vplate == query)
//                               .OrderByDescending(i => i.EntryDateTime)
//                               .Take(1);
//            }

//            var result = inOuts.ToList();

//            if (!string.IsNullOrEmpty(query) && !result.Any())
//            {
//                ViewBag.Message = "Vehicle is not registered.";
//            }

//            return View(result);
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterEntry(int vehicleId)
//        {
//            var entry = new InOut
//            {
//                VehicleId = vehicleId,
//                EntryDateTime = DateTime.Now
//            };

//            _context.InOuts.Add(entry);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterExit(int entryId)
//        {
//            var entry = _context.InOuts.FirstOrDefault(e => e.EntryId == entryId);
//            if (entry != null)
//            {
//                entry.ExitDateTime = DateTime.Now;
//                _context.InOuts.Update(entry);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction("Index");
//        }

//        public IActionResult SearchVehicle(string query)
//        {
//            var vehicles = _context.Vehicles.Where(v => v.Vplate.Contains(query)).ToList();
//            return View(vehicles);
//        }
//    }
//}





//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Web.Models;
//using System.Linq;
//using System.Threading.Tasks;
//using System;

//namespace Web.Controllers
//{
//    public class GuardController : Controller
//    {
//        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

//        public GuardController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index(string query)
//        {
//            var inOuts = _context.InOuts.Include(i => i.Vehicle).AsQueryable();

//            if (!string.IsNullOrEmpty(query))
//            {
//                var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vplate == query);
//                if (vehicle == null)
//                {
//                    TempData["Message"] = "Vehicle is not registered.";
//                    return View(new List<InOut>());
//                }

//                inOuts = inOuts.Where(i => i.Vehicle.Vplate == query)
//                               .OrderByDescending(i => i.EntryDateTime)
//                               .Take(1);
//            }

//            var result = inOuts.ToList();

//            ViewBag.Query = query;
//            return View(result);
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterEntry(string plateNumber)
//        {
//            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vplate == plateNumber);
//            if (vehicle == null)
//            {
//                TempData["Message"] = "Vehicle is not registered.";
//                return RedirectToAction("Index", new { query = plateNumber });
//            }

//            var entry = new InOut
//            {
//                VehicleId = vehicle.Vid,
//                EntryDateTime = DateTime.Now
//            };

//            _context.InOuts.Add(entry);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterExit(string plateNumber)
//        {
//            var inOut = _context.InOuts
//                .Include(i => i.Vehicle)
//                .Where(i => i.Vehicle.Vplate == plateNumber && i.ExitDateTime == null)
//                .OrderByDescending(i => i.EntryDateTime)
//                .FirstOrDefault();

//            if (inOut == null)
//            {
//                TempData["Message"] = "No active entry found for this vehicle.";
//                return RedirectToAction("Index", new { query = plateNumber });
//            }

//            inOut.ExitDateTime = DateTime.Now;
//            _context.InOuts.Update(inOut);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("Index");
//        }

//        public IActionResult SearchVehicle(string query)
//        {
//            var vehicles = _context.Vehicles.Where(v => v.Vplate.Contains(query)).ToList();
//            return View(vehicles);
//        }
//    }
//}
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Web.Models;
//using System.Linq;
//using System.Threading.Tasks;
//using System;
//using Microsoft.AspNetCore.Authorization;

//namespace Web.Controllers
//{
//    [Authorize(Roles = "Guard")]
//    public class GuardController : Controller
//    {
//        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

//        public GuardController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index(string query)
//        {
//            var inOuts = _context.InOuts.Include(i => i.Vehicle).AsQueryable();

//            if (!string.IsNullOrEmpty(query))
//            {
//                var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vplate == query);
//                if (vehicle == null)
//                {
//                    ViewBag.Message = "Vehicle is not registered.";
//                }
//                else
//                {
//                    inOuts = inOuts.Where(i => i.Vehicle.Vplate == query)
//                                   .OrderByDescending(i => i.EntryDateTime)
//                                   .Take(1);
//                }
//            }

//            var result = inOuts.ToList();

//            return View(result);
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterEntry(int vehicleId)
//        {
//            var entry = new InOut
//            {
//                VehicleId = vehicleId,
//                EntryDateTime = DateTime.Now
//            };

//            _context.InOuts.Add(entry);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterExit(int entryId)
//        {
//            var entry = _context.InOuts.FirstOrDefault(e => e.EntryId == entryId);
//            if (entry != null)
//            {
//                entry.ExitDateTime = DateTime.Now;
//                _context.InOuts.Update(entry);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction("Index");
//        }

//        public IActionResult SearchVehicle(string query)
//        {
//            var vehicles = _context.Vehicles.Where(v => v.Vplate.Contains(query)).ToList();
//            return View(vehicles);
//        }
//    }
//}



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Web.Models;

//namespace Web.Controllers
//{
//    public class GuardController : Controller
//    {
//        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

//        public GuardController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
//        {
//            _context = context;
//        }

//        // GET: Guard
//        public async Task<IActionResult> Index(string searchString)
//        {
//            var vehicles = from v in _context.Vehicles
//                           select v;

//            if (!String.IsNullOrEmpty(searchString))
//            {
//                vehicles = vehicles.Where(s => s.Vplate.Contains(searchString));
//            }

//            return View(await vehicles.Include(v => v.InOuts).ToListAsync());
//        }

//        // POST: Guard/In
//        [HttpPost]
//        public async Task<IActionResult> In(int vehicleId)
//        {
//            var entry = new InOut
//            {
//                VehicleId = vehicleId,
//                EntryDateTime = DateTime.Now
//            };
//            _context.Add(entry);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        // POST: Guard/Out
//        [HttpPost]
//        public async Task<IActionResult> Out(int entryId)
//        {
//            var entry = await _context.InOuts.FindAsync(entryId);
//            if (entry != null && entry.ExitDateTime == null)
//            {
//                entry.ExitDateTime = DateTime.Now;
//                _context.Update(entry);
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class GuardController : Controller
    {
        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

        public GuardController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
        {
            _context = context;
        }

        // GET: Guard
        // GET: Guard
        public async Task<IActionResult> Index(string searchString)
        {
            var vehicles = from v in _context.Vehicles
                           select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(s => s.Vplate.Contains(searchString));
            }

            var model = await vehicles.Include(v => v.InOuts).ToListAsync();
            return View(model);
        }


        // POST: Guard/In
        [HttpPost]
        public async Task<IActionResult> In(int vehicleId)
        {
            var entry = new InOut
            {
                VehicleId = vehicleId,
                EntryDateTime = DateTime.Now
            };
            _context.Add(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Guard/Out
        [HttpPost]
        public async Task<IActionResult> Out(int entryId)
        {
            var entry = await _context.InOuts.FindAsync(entryId);
            if (entry != null && entry.ExitDateTime == null)
            {
                entry.ExitDateTime = DateTime.Now;
                _context.Update(entry);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
