using Microsoft.AspNetCore.Mvc;
using System;

namespace CMCSystem.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            // Preloaded user data (you can change this)
            ViewData["UserName"] = "John Doe";
            ViewData["Role"] = "Programme Coordinator";
            ViewData["Email"] = "john.doe@college.edu";
            ViewData["LastLogin"] = DateTime.Now.ToString("f");

            // Preloaded claim summary (temporary)
            ViewData["ApprovedCount"] = 5;
            ViewData["DeclinedCount"] = 1;
            ViewData["PendingCount"] = 3;

            // This returns the Profile.cshtml view under /Views/Profile/
            return View("Profile");
        }
    }
}
