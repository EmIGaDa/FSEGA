namespace Proiect.Models
{
    public class Patient
    {

        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long CNP { get; set; }
        public string Email { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
