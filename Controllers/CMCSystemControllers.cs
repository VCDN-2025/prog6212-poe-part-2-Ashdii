using Microsoft.AspNetCore.Mvc;
using CMCSystem.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CMCSystem.Controllers
{
    public class ClaimController : Controller
    {
        public static List<Claim> claims = new List<Claim>
        {
            new Claim { Id = 1, PassengerName = "John Doe", ClaimType = "Lost Baggage", Description = "Suitcase missing from flight SA203", Status = "Pending" },
            new Claim { Id = 2, PassengerName = "Jane Smith", ClaimType = "Flight Delay", Description = "Claiming compensation for 6-hour delay", Status = "Approved" },
            new Claim { Id = 3, PassengerName = "Ali Khan", ClaimType = "Damaged Item", Description = "Laptop screen cracked in checked baggage", Status = "Rejected" }
        };

        public IActionResult Index()
        {
            return View(claims);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Claim newClaim, IFormFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, uploadedFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                    uploadedFile.CopyTo(stream);

                newClaim.DocumentPath = "/uploads/" + uploadedFile.FileName;
            }

            newClaim.Id = claims.Count + 1;
            newClaim.Status = "Submitted";
            claims.Add(newClaim);

            return RedirectToAction("Index");
        }
    }
}
