using G6RXAI_ADT_2023241.Models;
using G6RXAI_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Logic
{
    public class DoctorLogic
    {


        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorLogic(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void AddDoctor(Doctor doctor)
        {

            _doctorRepository.CreateDoctor(doctor);
            CheckDoctor(doctor);
        }

        public Doctor GetDoctorById(int id)
        {
            if (id <= 400)
            {
                throw new ArgumentException("This Doctor ID is not valid.");
            }
            return _doctorRepository.GetDoctorId(id);
        }

        public IEnumerable<Doctor> GetAllTheDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            CheckDoctor(doctor);
            if (doctor.DoctorId <= 400)
            {
                throw new ArgumentException("This Doctor ID is not valid.");
            }
            _doctorRepository.UpdateDoctor(doctor);
        }

        public void DeleteDoctor(int id)
        {
            if (id <= 400)
            {
                throw new ArgumentException("This Doctor ID is not valid.");
            }
            _doctorRepository.DeleteDoctor(id);
        }


        ////not-CrudMEthods
        private void CheckDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor), "Doctor's name cannot be null");
            }

            if (string.IsNullOrWhiteSpace(doctor.Name))
            {
                throw new ArgumentException("Doctor's name cannot be empty.", nameof(doctor));
            }

        }




        //// Method to retrieve car brands by a specific name pattern
        //public IEnumerable<CarBrand> GetCarBrandsByName(string namePattern)
        //{
        //    if (string.IsNullOrWhiteSpace(namePattern))
        //    {
        //        throw new ArgumentException("Name pattern cannot be empty or null.", nameof(namePattern));
        //    }

        //    return _doctorRepository.GetAllCarBrand()
        //        .Where(brand => brand.Name.Contains(namePattern, StringComparison.OrdinalIgnoreCase));
        //}

        //// Method to retrieve car brands sorted by name
        //public IEnumerable<CarBrand> GetCarBrandsOrderedByName()
        //{
        //    return _doctorRepository.GetAllCarBrand()
        //        .OrderBy(brand => brand.Name);
        //}

        //// Method to retrieve a limited number of car brands
        //public IEnumerable<CarBrand> GetTopCarBrands(int count)
        //{
        //    if (count <= 0)
        //    {
        //        throw new ArgumentException("Count must be positive.", nameof(count));
        //    }

        //    return _doctorRepository.GetAllCarBrand().Take(count);
        //}

        //public class CarBrandRentCount
        //{
        //    public CarBrand CarBrand { get; set; }
        //    public int RentCount { get; set; }
        //}

        ////first non-crud method which uses 2 tables counts the number of times a car brand has been rented.
        //public IEnumerable<CarBrandRentCount> GetCarBrandRentCounts()
        //{

        //    return _doctorRepository.GetAllCarBrand().Select(brand => new CarBrandRentCount
        //    {
        //        CarBrand = brand,
        //        RentCount = brand.CarRents.Count
        //    });
        //}









    }
}



