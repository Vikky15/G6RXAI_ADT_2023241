using Microsoft.AspNetCore.Mvc;
using G6RXAI_ADT_2023241.Logic;
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
        
    }
}