using G6RXAI_ADT_2023241.Models;
using G6RXAI_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static G6RXAI_ADT_2023241.Logic.PatientLogic;

namespace G6RXAI_ADT_2023241.Logic
{
    public class PatientLogic
    {
        private readonly IPatientRepository _patientRepository;


        public PatientLogic(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void AddCarModel(Patient patient)
        {

            _patientRepository.CreatePatient(patient);
            CheckPatient(patient);
        }

        public Patient GetPatientById(int id)
        {
            if (id <= 1000)
            {
                throw new ArgumentException("This is a wrong patient ID.");
            }
            return _patientRepository.GetPatientId(id);
        }

        public IEnumerable<Patient> GetAllThePatients()
        {
            return _patientRepository.GetAllPatients();
        }

        public void UpdatePatient(Patient patient)
        {
            CheckPatient(patient);
            if (patient.PatientId <= 1000)
            {
                throw new ArgumentException("This is a wrong patient ID.");
            }
            _patientRepository.UpdatePatient(patient);
        }

        public void DeletePatient(int id)
        {
            if (id <= 1000)
            {
                throw new ArgumentException("This is a wrong patient  ID.");
            }
            _patientRepository.DeletePatient(id);
        }
        //my Non crud method
       
        public class AppointmentLook
        {
            public Patient Patient { get; set; }
            public int AppointmentDuration { get; set; } 
        }
        public IEnumerable<AppointmentLook> GetAppointmentLook(DateTime startTime, DateTime endTime)
        {
            return _patientRepository.GetAllPatients()
                .Select(patient => new AppointmentLook
                {
                    Patient = patient,
                    AppointmentDuration = patient.Appointments.Count(duration => duration.AppointmentDate >= startTime && duration.AppointmentDate <= endTime)
                });
        }
        public class NumberOfAppointment
        {
            public Patient Patient { get; set; }
            public int AppointmentIn { get; set; }
        }

        public IEnumerable<NumberOfAppointment> GetAppointmentNumber()
        {

            return _patientRepository.GetAllPatients().Select(patient => new NumberOfAppointment
                                      {
                                          Patient = patient,
                                         AppointmentIn = patient.Appointments.Count
                                      });
        }
        private void CheckPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "Patient's name cannot be null");
            }

            if (string.IsNullOrWhiteSpace(patient.Name))
            {
                throw new ArgumentException("Patient's name cannot be empty.", nameof(patient));
            }


        }
    }
}