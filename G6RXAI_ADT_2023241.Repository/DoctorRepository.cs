using G6RXAI_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Repository
{
 public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalAppointmentDbContext Content;
        public DoctorRepository(HospitalAppointmentDbContext content )
        {
           Content  = content;
        }
        public void CreateDoctor(Doctor doctor)
        {
           Content.Doctors.Add( doctor );
            Content.SaveChanges();
            
        }

        public void DeleteDoctor(int id)
        {

            var doctors = Content.Doctors.Find(id);
            if (doctors != null)
            {
               Content.Doctors.Remove(doctors);
               Content.SaveChanges();
            }
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return Content.Doctors.ToList();
        }

        public Doctor GetDoctorId(int id)
        {
            return Content.Doctors.Find(id);
        }

        public void UpdateDoctor(Doctor doctor)
        {

            Content.Doctors.Update(doctor);
            Content.SaveChanges();

        }
    }
}
