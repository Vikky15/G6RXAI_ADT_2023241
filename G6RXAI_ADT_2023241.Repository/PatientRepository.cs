using G6RXAI_ADT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Repository
{
   public class PatientRepository : IPatientRepository
    {
        private readonly HospitalAppointmentDbContext Content;
        public PatientRepository(HospitalAppointmentDbContext content)
        {
            Content = content;
        }
        public void CreatePatient(Patient patient)
        {
            Content.Patients.Add(patient);  
           
  
        }

        public void DeletePatient(int id)
        {
            var patients = Content.Doctors.Find(id);
            if (patients != null)
            {
                Content.Doctors.Remove(patients);
                Content.SaveChanges();
            }
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return Content.Patients.ToList();
        }

        public Patient GetPatientId(int id)
        {
            return Content.Patients.Find(id);
        }

        public void UpdatePatient(Patient patient)
        {
            Content.Patients.Update(patient);
            Content.SaveChanges();
        }
    }
}
