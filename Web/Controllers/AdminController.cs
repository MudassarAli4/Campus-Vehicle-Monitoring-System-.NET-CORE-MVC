
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc;
//using Web.Models;
//using Microsoft.AspNetCore.Authorization;

//namespace Web.Controllers
//{
//    [Authorize(Roles = "Admin")]
//    public class AdminController : Controller
//    {
//        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

//        public AdminController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
//        {
//            _context = context;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult ManageGuards()
//        {
//            var guards = _context.Users.Where(u => u.Role == "Guard").ToList();
//            return View(guards);
//        }


//        //AddGuard
//        [HttpGet]
//        public IActionResult AddGuard()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult AddGuard(User model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Assigning role as "Guard" by default
//                model.Role = "Guard";

//                _context.Users.Add(model);
//                _context.SaveChanges();

//                return RedirectToAction("ManageGuards");
//            }

//            return View(model); // Return the same view with validation errors if ModelState is not valid
//        }


//        //update Guard
//        [HttpGet]
//        public IActionResult UpdateGuard(int id)
//        {
//            // Retrieve guard data from the database based on the ID
//            var guard = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Guard");
//            if (guard == null)
//            {
//                return NotFound(); // Handle case where guard is not found or role is not "Guard"
//            }

//            return View(guard); // Pass the guard data to the view
//        }

//        [HttpPost]
//        public async Task<IActionResult> UpdateGuard(User updatedGuard)
//        {
//            // Ensure the role remains as "Guard" after update
//            updatedGuard.Role = "Guard";

//            // Update the guard data in the database
//            _context.Users.Update(updatedGuard);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("ManageGuards"); // Redirect to ManageGuards page after update
//        }



//        // Delete
//        public IActionResult DeleteGuard(int id)
//        {
//            var guard = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Guard");
//            if (guard == null)
//            {
//                return NotFound(); // Handle case where guard is not found or role is not "Guard"
//            }

//            _context.Users.Remove(guard);
//            _context.SaveChanges();

//            return RedirectToAction("ManageGuards"); // Redirect to ManageGuards page after deletion
//        }




//       //Vehicle



//        public IActionResult GenerateReport()
//        {
//            // Logic for generating a report
//            return RedirectToAction("Index", "Admin");
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
//    [Authorize(Roles = "Admin")]
//    public class AdminController : Controller
//    {
//        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

//        public AdminController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        // Manage Guards
//        public IActionResult ManageGuards()
//        {
//            var guards = _context.Users.Where(u => u.Role == "Guard").ToList();
//            return View(guards);
//        }

//        // Add Guard
//        [HttpGet]
//        public IActionResult AddGuard()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult AddGuard(User model)
//        {
//            if (ModelState.IsValid)
//            {
//                model.Role = "Guard"; // Assigning role as "Guard" by default
//                _context.Users.Add(model);
//                _context.SaveChanges();
//                return RedirectToAction("ManageGuards");
//            }
//            return View(model); // Return the same view with validation errors if ModelState is not valid
//        }

//        // Update Guard
//        [HttpGet]
//        public IActionResult UpdateGuard(int id)
//        {
//            var guard = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Guard");
//            if (guard == null)
//            {
//                return NotFound(); // Handle case where guard is not found or role is not "Guard"
//            }
//            return View(guard);
//        }

//        [HttpPost]
//        public async Task<IActionResult> UpdateGuard(User updatedGuard)
//        {
//            updatedGuard.Role = "Guard"; // Ensure the role remains as "Guard" after update
//            _context.Users.Update(updatedGuard);
//            await _context.SaveChangesAsync();
//            return RedirectToAction("ManageGuards");
//        }

//        // Delete Guard
//        public IActionResult DeleteGuard(int id)
//        {
//            var guard = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Guard");
//            if (guard == null)
//            {
//                return NotFound(); // Handle case where guard is not found or role is not "Guard"
//            }
//            _context.Users.Remove(guard);
//            _context.SaveChanges();
//            return RedirectToAction("ManageGuards");
//        }

//        // Manage Vehicles
//        public IActionResult ManageVehicles()
//        {
//            var vehicles = _context.Vehicles.ToList();
//            return View(vehicles);
//        }

//        // Add Vehicle
//        [HttpGet]
//        public IActionResult AddVehicle()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult AddVehicle(Vehicle model)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Vehicles.Add(model);
//                _context.SaveChanges();
//                return RedirectToAction("ManageVehicles");
//            }
//            return View(model);
//        }

//        // Update Vehicle
//        [HttpGet]
//        public IActionResult UpdateVehicle(int id)
//        {
//            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vid == id);
//            if (vehicle == null)
//            {
//                return NotFound();
//            }
//            return View(vehicle);
//        }

//        [HttpPost]
//        public async Task<IActionResult> UpdateVehicle(Vehicle updatedVehicle)
//        {
//            _context.Vehicles.Update(updatedVehicle);
//            await _context.SaveChangesAsync();
//            return RedirectToAction("ManageVehicles");
//        }

//        //// Delete Vehicle
//        //public IActionResult DeleteVehicle(int id)
//        //{
//        //    var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vid == id);
//        //    if (vehicle == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    _context.Vehicles.Remove(vehicle);
//        //    _context.SaveChanges();
//        //    return RedirectToAction("ManageVehicles");
//        //}
//        // Delete Vehicle
//        public IActionResult DeleteVehicle(int id)
//        {
//            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vid == id);
//            if (vehicle == null)
//            {
//                return NotFound();
//            }
//            _context.Vehicles.Remove(vehicle);
//            _context.SaveChanges();
//            return RedirectToAction("ManageVehicles");
//        }
//        // Generate Report
//        public IActionResult GenerateReport()
//        {
//            // Logic for generating a report
//            return RedirectToAction("Index", "Admin");
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

        public AdminController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Manage Guards
        public IActionResult ManageGuards()
        {
            var guards = _context.Users.Where(u => u.Role == "Guard").ToList();
            return View(guards);
        }

        // Add Guard
        [HttpGet]
        public IActionResult AddGuard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuard(User model)
        {
            if (ModelState.IsValid)
            {
                model.Role = "Guard"; // Assigning role as "Guard" by default
                _context.Users.Add(model);
                try
                {
                    _context.SaveChanges();
                    return RedirectToAction("ManageGuards");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex, "adding the guard");
                    return View(model);
                }
            }
            return View(model); // Return the same view with validation errors if ModelState is not valid
        }

        // Update Guard
        [HttpGet]
        public IActionResult UpdateGuard(int id)
        {
            var guard = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Guard");
            if (guard == null)
            {
                return NotFound(); // Handle case where guard is not found or role is not "Guard"
            }
            return View(guard);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuard(User updatedGuard)
        {
            updatedGuard.Role = "Guard"; // Ensure the role remains as "Guard" after update
            _context.Users.Update(updatedGuard);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageGuards");
            }
            catch (DbUpdateException ex)
            {
                HandleDbUpdateException(ex, "updating the guard");
                return View(updatedGuard);
            }
        }

        // Delete Guard
        public IActionResult DeleteGuard(int id)
        {
            var guard = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Guard");
            if (guard == null)
            {
                return NotFound(); // Handle case where guard is not found or role is not "Guard"
            }
            _context.Users.Remove(guard);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("ManageGuards");
            }
            catch (DbUpdateException ex)
            {
                HandleDbUpdateException(ex, "deleting the guard");
                return RedirectToAction("ManageGuards");
            }
        }

        // Manage Vehicles
        public IActionResult ManageVehicles()
        {
            var vehicles = _context.Vehicles.ToList();
            return View(vehicles);
        }

        // Add Vehicle
        [HttpGet]
        public IActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle model)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(model);
                try
                {
                    _context.SaveChanges();
                    return RedirectToAction("ManageVehicles");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex, "adding the vehicle");
                    return View(model);
                }
            }
            return View(model);
        }

        // Update Vehicle
        [HttpGet]
        public IActionResult UpdateVehicle(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vid == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVehicle(Vehicle updatedVehicle)
        {
            _context.Vehicles.Update(updatedVehicle);
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageVehicles");
            }
            catch (DbUpdateException ex)
            {
                HandleDbUpdateException(ex, "updating the vehicle");
                return View(updatedVehicle);
            }
        }

        // Delete Vehicle
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Vid == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(vehicle);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("ManageVehicles");
            }
            catch (DbUpdateException ex)
            {
                HandleDbUpdateException(ex, "deleting the vehicle");
                return RedirectToAction("ManageVehicles");
            }
        }

        // Generate Report
        public IActionResult GenerateReport()
        {
            // Logic for generating a report
            return RedirectToAction("Index", "Admin");
        }

        // Helper method to handle DbUpdateException
        private void HandleDbUpdateException(DbUpdateException ex, string action)
        {
            // Log the exception or display an error message to the user
            Console.WriteLine($"Error occurred while {action}:");
            Console.WriteLine(ex.Message);

            // Check if there's an inner exception
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception:");
                Console.WriteLine(ex.InnerException.Message);
            }

            // Handle the exception based on the specific error
            // For example, you can roll back changes, display an error message to the user, etc.
            ModelState.AddModelError("", $"An error occurred while {action}. Please try again.");
        }
    }
}
