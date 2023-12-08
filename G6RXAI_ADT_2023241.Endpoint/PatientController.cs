using Microsoft.AspNetCore.Mvc;
using G6RXAI_ADT_2023241.Logic;
using static G6RXAI_ADT_2023241.Logic.DoctorLogic;
using G6RXAI_ADT_2023241.Models;

namespace G6RXAI_ADT_2023241.Endpoint
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
       
            private readonly PatientLogic _patientLogic;

            public PatientController(PatientLogic patientLogic)
            {
                _patientLogic = patientLogic;
            }
        [HttpPost]
        //Posting
        public IActionResult Post([FromBody]Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientLogic.AddPatient(patient);

            return CreatedAtAction(nameof(GetpatientById), new { id = patient.PatientId }, patient);
        }

        [HttpGet("{id}", Name = "GetpatientById")]
        public IActionResult GetpatientById(int id)
        {
            var appointment = _patientLogic.GetPatientById(id);
            if (id <= 600)
            {
                return BadRequest("Invalid patient ID");
            }
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            return Ok(_patientLogic.GetAllThePatients());
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (id <= 1000 || id != patient.PatientId)
            {
                return BadRequest("Invalid patient ID.");
            }

            try
            {
                _patientLogic.UpdatePatient(patient);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE AREA 
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            if (id <= 1000)
            {
                return BadRequest("Invalid patient ID.");
            }

            try
            {
                _patientLogic.DeletePatient(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}