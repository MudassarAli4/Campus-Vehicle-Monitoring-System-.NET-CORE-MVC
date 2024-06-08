using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        //public IActionResult Dashboard()
        //{
        //    if (User.IsInRole("SuperAdmin"))
        //    {
        //        return RedirectToAction("Index", "SuperAdmin");
        //    }
        //    else if (User.IsInRole("Admin"))
        //    {
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else if (User.IsInRole("Guard"))
        //    {
        //        return RedirectToAction("Index", "Guard");
        //    }

        //    return View("AccessDenied"); // Redirect to AccessDenied view if no role matches
        //}

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}
