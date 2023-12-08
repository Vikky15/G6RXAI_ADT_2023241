using Microsoft.AspNetCore.Mvc;
using static G6RXAI_ADT_2023241.Logic.AppointmentLogic;
using G6RXAI_ADT_2023241.Logic;
using G6RXAI_ADT_2023241.Models;
namespace G6RXAI_ADT_2023241.Endpoint
{ 
        [ApiController]
[Route("[controller]")]
    public class AppointmentController: ControllerBase
    {
        private readonly AppointmentLogic _appointmentLogic;
        public AppointmentController(AppointmentLogic appointmentLogic)
        {
            _appointmentLogic = appointmentLogic;
        }
        [HttpPost]
        //Posting
        public IActionResult Post([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appointmentLogic.AddAppointment(appointment);

            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpGet("{id}", Name = "GetAppointmentById")]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = _appointmentLogic.GetAppointmentById(id);
            if (id <= 600)
            {
                return BadRequest("Invalid Appointment ID");
            }
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAllAppointments()
        {
            return Ok(_appointmentLogic.GetAllTheAppointments());
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (id <= 600 || id != appointment. AppointmentId)
            {
                return BadRequest("Invalid appointment ID.");
            }

            try
            {
                _appointmentLogic.UpdateAppointment(appointment);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE AREA 
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            if (id <= 600)
            {
                return BadRequest("Invalid Appoinment ID.");
            }

            try
            {
                _appointmentLogic.DeleteAppointment(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


      

    }
}
