using SQLite;

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

        public string Name { get; set; }
        public int Age { get; set; }
        public Function Function { get; set; }

        public string Email { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public ICollection<Review>? Reviews { get; set; }

    }
}
