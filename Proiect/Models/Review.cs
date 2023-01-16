using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Review
    {

        public int ReviewId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        public Patient Patient { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentID {get; set; }

        public Appointment Appointment { get; set; }

        public string Description { get; set; }
    }
}
