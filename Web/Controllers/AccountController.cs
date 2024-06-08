//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using Web.Models;

//namespace Web.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

//        public AccountController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(string username, string password)
//        {
//            var user = _context.Users.SingleOrDefault(u => u.Name == username && u.Password == password);
//            if (user != null)
//            {
//                var claims = new List<Claim>
//        {
//            new Claim(ClaimTypes.Name, user.Name),
//            new Claim(ClaimTypes.Role, user.Role)
//        };

//                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//                var authProperties = new AuthenticationProperties
//                {
//                    IsPersistent = true
//                };

//                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

//                // Redirect users based on their roles
//                if (User.IsInRole("SuperAdmin"))
//                {
//                    return RedirectToAction("Index", "SuperAdmin");
//                }
//                else if (User.IsInRole("Admin"))
//                {
//                    return RedirectToAction("Index", "Admin");
//                }
//                else if (User.IsInRole("Guard"))
//                {
//                    return RedirectToAction("Index", "Guard");
//                }
//                else
//                {
//                    return RedirectToAction("Index", "Home"); // Redirect to default page if role is not recognized
//                }
//            }

//            ViewBag.ErrorMessage = "Invalid username or password";
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            return RedirectToAction("Index", "Home");
//        }

//        public IActionResult AccessDenied()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly CUsersAhmadMurtazaDocumentsEndMdfContext _context;

        public AccountController(CUsersAhmadMurtazaDocumentsEndMdfContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Name == username && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Redirect based on role
                if (user.Role == "SuperAdmin")
                {
                    return RedirectToAction("Index", "SuperAdmin");
                }
                else if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Role == "Guard")
                {
                    return RedirectToAction("Index", "Guard");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
