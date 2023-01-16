using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        
        public Patient Patient { get; set; }

    }
}
