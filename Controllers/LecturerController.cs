using Microsoft.AspNetCore.Mvc;
using CMCSystem.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CMCSystem.Controllers
{
    public class LecturerController : Controller
    {
        public static List<Lecturer> _lecturerClaims = new List<Lecturer>();

        public IActionResult Index() => View(_lecturerClaims.OrderByDescending(c => c.SubmittedDate).ToList());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Lecturer newClaim, IFormFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, uploadedFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                    uploadedFile.CopyTo(stream);

                newClaim.DocumentPath = "/uploads/" + uploadedFile.FileName;
            }

            newClaim.Id = _lecturerClaims.Count + 1;
            newClaim.Status = "Submitted";
            newClaim.SubmittedDate = DateTime.Now;

            _lecturerClaims.Add(newClaim);
            TempData["Success"] = "Claim submitted successfully!";

            return RedirectToAction("Index");
        }
    }
}
