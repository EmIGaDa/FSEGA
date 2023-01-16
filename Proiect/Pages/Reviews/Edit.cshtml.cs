using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;
        public Appointment Appointment { get; set; } = default!;
        public Doctor Doctor { get; set; } = default!;
        public Patient Patient { get; set; } = default!;

        public IList<Doctor> Doctors { get; set; } = default!;
        public IList<Patient> Patients { get; set; } = default!;

        public IList<Appointment> Appointments { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review =  await _context.Review.FirstOrDefaultAsync(m => m.ReviewId == id);
            
            if (review == null)
            {
                return NotFound();
            }
            Review = review;
            Appointment =await _context.Appointment.FirstOrDefaultAsync(m => m.ID == review.AppointmentID);
            Doctor = await _context.Doctor.FirstOrDefaultAsync(m => m.DoctorId == review.DoctorID);
            Patient = await _context.Patient.FirstOrDefaultAsync(m => m.PatientId == review.PatientID);

            Doctors = _context.Doctor.ToList();
            Patients = _context.Patient.ToList();
            Appointments = _context.Appointment.ToList();
            ViewData["AppointmentID"] = new SelectList(_context.Appointment, "ID", "ID");
           ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorId", "DoctorId");
           ViewData["PatientID"] = new SelectList(_context.Patient, "PatientId", "PatientId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Attach(Review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.ReviewId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReviewExists(int id)
        {
          return _context.Review.Any(e => e.ReviewId == id);
        }
    }
}
