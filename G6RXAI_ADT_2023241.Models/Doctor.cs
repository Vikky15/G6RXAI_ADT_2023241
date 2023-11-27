using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace G6RXAI_ADT_2023241.Models
{
   
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        public virtual Appointment Appointment { get; set; }
    }

}