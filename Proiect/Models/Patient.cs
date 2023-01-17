using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Patient
    {

        public int PatientId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Range(1, 105)]
        public int Age { get; set; }

        [MinLength(13, ErrorMessage = "CNP must contain 13 numbers"), MaxLength(13, ErrorMessage = "CNP must contain 13 numbers")]
        public long CNP { get; set; }

        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
            ErrorMessage = "Email is required and must be properly formatted.")]
        public string Email { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
