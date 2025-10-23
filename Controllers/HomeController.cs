using System.Diagnostics;
using CMCSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMCSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ?? New Profile action (dummy logged-in user)
        public IActionResult Profile()
        {
            // Example: fetch user info (replace with your actual auth system)
            ViewData["UserName"] = "Admin User";
            ViewData["Role"] = "Admin"; // or "User"
            ViewData["Email"] = "admin@example.com";
            ViewData["LastLogin"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // Pending claims counts
            int pendingLecturerClaims = AdminController._lecturerClaims.Count(c => c.Status == "Submitted");
            int pendingGeneralClaims = AdminController._claims.Count(c => c.Status == "Submitted");

            ViewData["PendingLecturerClaims"] = pendingLecturerClaims;
            ViewData["PendingGeneralClaims"] = pendingGeneralClaims;

            return View();
        }

    }
}
