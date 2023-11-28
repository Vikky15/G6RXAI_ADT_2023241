using G6RXAI_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Repository
{
    internal class DoctorRepository : IDoctorRepository
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
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return Content.Doctors.ToList();
        }

        public Doctor GetDoctorId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient(Doctor doctor)
        {

            Content.Doctors.Update(doctor);
            Content.SaveChanges();

        }
    }
}
