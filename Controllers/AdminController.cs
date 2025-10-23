using CMCSystem.Controllers;
using CMCSystem.Models;
using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    public static List<Lecturer> _lecturerClaims => LecturerController._lecturerClaims;
    public static List<Claim> _claims => ClaimController.claims;

    // Programme Coordinator View
    public IActionResult ProgrammeCoordinator()
    {
        // Only pending/submitted claims
        var claims = new List<dynamic>();

        claims.AddRange(_lecturerClaims
            .Where(c => c.Status == "Submitted")
            .Select(c => new
            {
                c.Id,
                Name = c.Name,
                c.HoursWorked,
                c.HourlyRate,
                Notes = c.AdditionalNotes,
                c.DocumentPath,
                c.Status,
                Type = "Lecturer"
            }));

        claims.AddRange(_claims
            .Where(c => c.Status == "Submitted")
            .Select(c => new
            {
                c.Id,
                Name = c.PassengerName,
                HoursWorked = (double?)null,
                HourlyRate = (decimal?)null,
                Notes = c.Description,
                c.DocumentPath,
                c.Status,
                Type = "Claim"
            }));

        return View("~/Views/Admin/ProgrammeCoordinator.cshtml", claims);
    }

    // Academic Manager View
    public IActionResult AcademicManager()
    {
        // Only pending/submitted claims
        var claims = new List<dynamic>();

        claims.AddRange(_lecturerClaims
            .Where(c => c.Status == "Submitted")
            .Select(c => new
            {
                c.Id,
                Name = c.Name,
                c.HoursWorked,
                c.HourlyRate,
                Notes = c.AdditionalNotes,
                c.DocumentPath,
                c.Status,
                Type = "Lecturer"
            }));

        claims.AddRange(_claims
            .Where(c => c.Status == "Submitted")
            .Select(c => new
            {
                c.Id,
                Name = c.PassengerName,
                HoursWorked = (double?)null,
                HourlyRate = (decimal?)null,
                Notes = c.Description,
                c.DocumentPath,
                c.Status,
                Type = "Claim"
            }));

        return View("~/Views/Admin/AcademicManager.cshtml", claims);
    }

    // Programme Coordinator actions
    [HttpPost]
    public IActionResult Verify(string type, int id)
    {
        if (type == "Lecturer")
            _lecturerClaims.FirstOrDefault(c => c.Id == id)!.Status = "Verified";
        else
            _claims.FirstOrDefault(c => c.Id == id)!.Status = "Verified";

        return RedirectToAction("ProgrammeCoordinator");
    }

    [HttpPost]
    public IActionResult Reject(string type, int id, string returnTo)
    {
        if (type == "Lecturer")
            _lecturerClaims.FirstOrDefault(c => c.Id == id)!.Status = "Rejected";
        else
            _claims.FirstOrDefault(c => c.Id == id)!.Status = "Rejected";

        return returnTo == "ProgrammeCoordinator"
            ? RedirectToAction("ProgrammeCoordinator")
            : RedirectToAction("AcademicManager");
    }

    // Academic Manager actions
    [HttpPost]
    public IActionResult Approve(string type, int id)
    {
        if (type == "Lecturer")
            _lecturerClaims.FirstOrDefault(c => c.Id == id)!.Status = "Approved";
        else
            _claims.FirstOrDefault(c => c.Id == id)!.Status = "Approved";

        return RedirectToAction("AcademicManager");
    }

    // Download file
    public IActionResult Download(string type, int id)
    {
        string filePath = null;

        if (type == "Lecturer")
            filePath = _lecturerClaims.FirstOrDefault(c => c.Id == id)?.DocumentPath;
        else
            filePath = _claims.FirstOrDefault(c => c.Id == id)?.DocumentPath;

        if (!string.IsNullOrEmpty(filePath))
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));
            if (System.IO.File.Exists(fullPath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(fullPath);
                return File(fileBytes, "application/octet-stream", Path.GetFileName(fullPath));
            }
        }

        return NotFound();
    }
}
