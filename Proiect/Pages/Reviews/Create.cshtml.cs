using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get; set; } = default!;
        public IList<Patient> Patient { get; set; } = default!;

        public IList<Appointment> Appointment { get; set; } = default!;

        public IActionResult OnGet()
        {
        ViewData["AppointmentID"] = new SelectList(_context.Appointment, "ID", "ID");
        ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorId", "DoctorId");
        ViewData["PatientID"] = new SelectList(_context.Patient, "PatientId", "PatientId");

            Doctor = _context.Doctor.ToList();
            Patient = _context.Patient.ToList();
            Appointment = _context.Appointment.ToList();
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
