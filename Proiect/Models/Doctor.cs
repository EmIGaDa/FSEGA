using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public enum Function
    {
        Cardiologist,
        Urologist,
        Surgeon,
        Ophthalmologist
    }

    public class Doctor
    {
        public int DoctorId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Range(23, 80)]
        public int Age { get; set; }
        public Function Function { get; set; }

        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
            ErrorMessage = "Email is required and must be properly formatted.")]
        public string Email { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public ICollection<Review>? Reviews { get; set; }

    }
}
