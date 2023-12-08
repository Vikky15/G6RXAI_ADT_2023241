using Microsoft.AspNetCore.Mvc;
using G6RXAI_ADT_2023241.Logic;
using static  G6RXAI_ADT_2023241.Logic.DoctorLogic;
using G6RXAI_ADT_2023241.Models;

namespace G6RXAI_ADT_2023241.Endpoint
{
    [ApiController]
    [Route("[controller]")]
    

       
        public class  DoctorController : ControllerBase
       {
            private readonly DoctorLogic _doctorLogic;

            public DoctorController(DoctorLogic doctorlogic)
            {
                _doctorLogic = doctorlogic;
    

            }
        [HttpPost]
        //Posting
        public IActionResult Post([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _doctorLogic.AddDoctor(doctor);

            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.DoctorId }, doctor);
        }

        [HttpGet("{id}", Name = "GetDoctorById")]
        public IActionResult GetDoctorById(int id)
        {
            var appointment = _doctorLogic.GetDoctorById(id);
            if (id <= 400)
            {
                return BadRequest("Invalid Doctor ID");
            }
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetAllDoctors()
        {
            return Ok(_doctorLogic.GetAllTheDoctors());
        }


        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            if (id <= 400 || id != doctor.DoctorId)
            {
                return BadRequest("Invalid Doctor ID.");
            }

            try
            {
                _doctorLogic.UpdateDoctor(doctor);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE AREA 
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            if (id <= 400)
            {
                return BadRequest("Invalid Doctor ID.");
            }

            try
            {
                _doctorLogic.DeleteDoctor(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        } 
    }
    
}
