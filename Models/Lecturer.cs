using System;
using System.ComponentModel.DataAnnotations;

namespace CMCSystem.Models
{
    public class Lecturer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the number of hours worked.")]
        [Range(0, 1000, ErrorMessage = "Hours worked must be between 0 and 1000.")]
        public double HoursWorked { get; set; }

        [Required(ErrorMessage = "Please enter your hourly rate.")]
        [Range(0, 10000, ErrorMessage = "Hourly rate must be between 0 and 10000.")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Additional Notes")]
        public string AdditionalNotes { get; set; }

        public string DocumentPath { get; set; }

        [Display(Name = "Claim Status")]
        public string Status { get; set; } = "Submitted";

        [Display(Name = "Submitted Date")]
        public DateTime SubmittedDate { get; set; } = DateTime.Now;
    }
}
