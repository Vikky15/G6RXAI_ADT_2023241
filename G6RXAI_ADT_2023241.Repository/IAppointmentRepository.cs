using G6RXAI_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Repository
{
 public  interface IAppointmentRepository
    {

        void CreateAppointment(Appointment appointment);
        Appointment GetAppointmentId(int id);
        IEnumerable<Appointment> GetAllAppointment();
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
    }
}
