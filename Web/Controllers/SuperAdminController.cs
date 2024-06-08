using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

        public SuperAdminController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
        {
            _context = context;
        }

        // Display all users
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        public IActionResult Register()
        {
            return View();
        }

        // Add user
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Register");
            }
            return View("AddUser", user);
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "SuperAdmin");
            }
            return View("Register", user);
        }

        // Update user
        //[HttpPost]
        //public IActionResult UpdateUser(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Users.Update(user);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View("UpdateUser", user);
        //}

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            // Retrieve user data from the database based on the ID
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Handle case where user is not found
            }

            return View(user); // Pass the user data to the view
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User updatedUser)
        {
            // Update the user data in the database
            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirect to SuperAdmin page after update
        }






        // Delete user
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
