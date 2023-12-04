using Microsoft.AspNetCore.Mvc;
using G6RXAI_ADT_2023241.Logic;
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
        }
    
}
