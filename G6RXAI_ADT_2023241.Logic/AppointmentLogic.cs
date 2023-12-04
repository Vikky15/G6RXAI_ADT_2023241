using G6RXAI_ADT_2023241.Models;
using G6RXAI_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Logic
{
    public class AppointmentLogic
    {
        private readonly IAppointmentRepository _appointmentRepository;


        public AppointmentLogic(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void AddCarModel(Appointment appointment)
        {

            _appointmentRepository.CreateAppointment(appointment);
            CheckAppointmentParameter(appointment);
        }

        public Appointment GetPatientById(int id)
        {
            if (id <= 409)
            {
                throw new ArgumentException("This is a wrong patient ID.");
            }
            return _appointmentRepository.GetAppointmentId(id);
        }

        public IEnumerable<Appointment> GetAllTheAppointments()
        {
            return _appointmentRepository.GetAllAppointment();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            CheckAppointmentParameter(appointment);
            if (appointment.AppointmentId <= 1000)
            {
                throw new ArgumentException("This is a wrong patient ID.");
            }
            _appointmentRepository.UpdateAppointment(appointment);
        }

        public void DeleteAppointmentt(int id)
        {
            if (id <= 409)
            {
                throw new ArgumentException("This is a wrong patient  ID.");
            }
            _appointmentRepository.DeleteAppointment(id);
        }

        private void CheckAppointmentParameter(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null");
            }


        }
        public class AppointmentWithDoctor
        {
            public Appointment actualAppointment { get; set; }
            public Doctor actualDoctor { get; set; }
        }


    }
}
