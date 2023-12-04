using Microsoft.AspNetCore.Mvc;
using G6RXAI_ADT_2023241.Logic;
namespace G6RXAI_ADT_2023241.Endpoint
{ 
        [ApiController]
[Route("[controller]")]
public class AppointmentController
    {
        private readonly AppointmentLogic _appointmentLogic;
        public AppointmentController(AppointmentLogic appointmentLogic)
        {
            _appointmentLogic = appointmentLogic;
        }
    }
}
