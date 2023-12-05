using Moq;
using NUnit.Framework;
using G6RXAI_ADT_2023241.Models;
using G6RXAI_ADT_2023241.Logic;
using G6RXAI_ADT_2023241.Repository;


namespace G6RXAI_ADT_2023241.Test
{
    [TestFixture]
    public class PatientLogicTest
    {


        private Mock<IPatientRepository> _mockRepository;
        private PatientLogic _patientLogic;
        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IPatientRepository>();
            _patientLogic = new PatientLogic(_mockRepository.Object);
        }

        [Test]
        public void KnowNumber()
        {
            // Arrange
            var Patients = new List<Patient>
        {
              new Patient { PatientId = 1001, Name = "John ",BirthDate =  DateTime.Parse("1999-08-24"), Appointments = new List<Appointment> { new Appointment(), new Appointment() } } ,
              new Patient { PatientId = 1002, Name = "Greg",BirthDate =  DateTime.Parse("2019-08-14"), Appointments = new List<Appointment> { new Appointment()} } ,
              new Patient { PatientId = 1003, Name = "San",BirthDate =  DateTime.Parse("2016-10-24"), Appointments = new List<Appointment> () } 
            
        };
            _mockRepository.Setup(repo => repo.GetAllPatients()).Returns(Patients.AsQueryable());

            // Act
            var result = _patientLogic.GetAppointmentNumber();

            // Assert
            var resultList = result.ToList();
            Assert.AreEqual(3, resultList.Count);
            Assert.AreEqual(2, resultList.First(r => r.Patient.PatientId ==1001).AppointmentIn);
            Assert.AreEqual(1, resultList.First(r => r.Patient.PatientId == 1002).AppointmentIn);
            Assert.AreEqual(0, resultList.First(r => r.Patient.PatientId == 1003).AppointmentIn);
        }
        [Test]
        public void DeletePatientOnRepository()
        {
            // Arrange
            var PatientIdToBeDeleted = 1001;
            _mockRepository.Setup(repo => repo.DeletePatient(It.IsAny<int>()));

            // Act
            _patientLogic.DeletePatient(PatientIdToBeDeleted);

            // Assert
            _mockRepository.Verify(repo => repo.DeletePatient(PatientIdToBeDeleted), Times.Once);
        }
        [Test]
        public void GetPatientAppointmentDetails()
        {
            // Arrange
            var startTime = new DateTime(2023, 01, 01,0,0,0);
            var endTime = new DateTime(2023, 12, 31,23,59,59);
            var Patient = new List<Patient>
        {
            new Patient
            {
                PatientId = 1,
                Name = "Patient 1",
                Appointments = new List< Appointment>
                {
                    new  Appointment  { AppointmentId = 1, AppointmentDate = new DateTime(2023, 01, 12,16,30,0) },
                    new Appointment  {AppointmentId = 2, AppointmentDate = new DateTime(2023, 03, 25,12,0,0) }
                }
            },
            new Patient
            {
                PatientId = 2,
                Name = "Patient 2",
                Appointments = new List<Appointment>
                {
                    new Appointment{ AppointmentId = 3, AppointmentDate = new DateTime(2023, 03, 06,8,0,0) }
                }
            }
        };

            _mockRepository.Setup(repo => repo.GetAllPatients()).Returns(Patient.AsQueryable());

            // Act
            var result = _patientLogic.GetAppointmentLook(startTime, endTime);

            // Assert
            var resultList = result.ToList();
            Assert.AreEqual(2, resultList.Count); // Ensure we got a summary for each model
            Assert.AreEqual(2, resultList.First(r => r.Patient.PatientId == 1).AppointmentDuration);
            Assert.AreEqual(1, resultList.First(r => r.Patient.PatientId == 2).AppointmentDuration);
        }
    }
}