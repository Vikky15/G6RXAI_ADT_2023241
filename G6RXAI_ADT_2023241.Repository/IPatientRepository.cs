using G6RXAI_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Repository
{
    public interface IPatientRepository
    {

        void CreatePatient(Patient patient);
        Patient GetPatientId(int id);
        IEnumerable<Patient> GetAllPatients();
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}
