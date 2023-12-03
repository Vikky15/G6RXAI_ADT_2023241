using G6RXAI_ADT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace G6RXAI_ADT_2023241.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalAppointmentDbContext Content;
        public AppointmentRepository(HospitalAppointmentDbContext content)
        {
            Content = content;
        }
        public void CreateAppointment(Appointment appointment)
        {
            Content.Appointments.Add(appointment);
            Content.SaveChanges(); 
        }

        public void DeleteAppointment(int id)
        {
            var appointments = Content.Appointments.Find(id);
            if (appointments != null)
            {
                Content.Appointments.Remove(appointments);
                Content.SaveChanges();
            }
        }

        public IEnumerable<Appointment> GetAllAppointment()
        {
            return Content.Appointments.ToList();
        }

        public Appointment GetAppointmentId(int id)
        {
            return Content.Appointments.Find(id);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            Content.Update(appointment);
            Content.SaveChanges();
        }
    }
}