using G6RXAI_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Repository
{
    public interface IDoctorRepository
    {

        void CreateDoctor(Doctor doctor);
        Doctor GetDoctorId(int id);
        IEnumerable<Doctor> GetAllDoctors();
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);
    }
}
