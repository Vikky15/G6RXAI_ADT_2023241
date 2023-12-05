using Moq;
using NUnit.Framework;
using G6RXAI_ADT_2023241.Logic;
using G6RXAI_ADT_2023241.Models;
using G6RXAI_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Test
{
    [TestFixture]
   public class DoctorLogicTest
    {
        private Mock<IDoctorRepository> _mockRepository;
        private  DoctorLogic doctorLogic;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IDoctorRepository>();
            doctorLogic = new DoctorLogic(_mockRepository.Object);
        }
        [Test]
        public void ExistingDoctor()
        {
            // Arrange
            var Doctor = new Doctor { Name = "Frederick Cruz" };
            _mockRepository.Setup(repo => repo.CreateDoctor(It.IsAny<Doctor>()));

            // Act
            doctorLogic.AddDoctor(Doctor);

            // Assert
            _mockRepository.Verify(repo => repo.CreateDoctor(It.Is<Doctor>(cb => cb.Name == "Frederick Cruz")), Times.Once);


        }
        [Test]
        public void GetAllDoctorInRepository()
        {
            // Arrange
            var expectedDoctors = new List<Doctor>
    {
        new Doctor { DoctorId = 401, Name = "Doctor1" },
        new Doctor { DoctorId = 402, Name = "Doctor2" }
    };
            _mockRepository.Setup(repo => repo.GetAllDoctors()).Returns(expectedDoctors);

            // Act
            var result = doctorLogic.GetAllTheDoctors();

            // Assert
            Assert.That(result, Is.EqualTo(expectedDoctors));
            _mockRepository.Verify(repo => repo.GetAllDoctors(), Times.Once);
        }

        [Test]
        public void DeleteDoctorOnRepository()
        {
            // Arrange
            var DoctorIdToBeDeleted= 401;
            _mockRepository.Setup(repo => repo.DeleteDoctor(It.IsAny<int>()));

            // Act
            doctorLogic.DeleteDoctor(DoctorIdToBeDeleted);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteDoctor(DoctorIdToBeDeleted), Times.Once);
        }
        [Test]
        public void DeleteDoctorInvalidId()
        {
            // Arrange
            var invalidDoctorId = -1;

            // Act & Assert
            var nonexist = Assert.Throws<ArgumentException>(() => doctorLogic.DeleteDoctor(invalidDoctorId));
            Assert.That(nonexist.Message, Is.EqualTo("Invalid Doctor ID."));
        }
        [Test]
        public void GetDoctorwithValidId()
        {
            // Arrange
            var doctorId = 402;
            _mockRepository.Setup(repo => repo.GetDoctorId(doctorId))
                           .Returns(new Doctor { DoctorId = doctorId, Name = "Frederick Cruz" });

            // Act
            var result = doctorLogic.GetDoctorById(doctorId);

            // Assert
            _mockRepository.Verify(repo => repo.GetDoctorId(doctorId), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DoctorId, Is.EqualTo(doctorId));
        }

        [Test]
        public void UpdateDoctorOnRepository() 
        {
            // Arrange
            var DoctorToUpdate = new Doctor { DoctorId = 1, Name = "UpdatedDoctor" };
            _mockRepository.Setup(repo => repo.UpdateDoctor(It.IsAny<Doctor>()));

            // Act
            doctorLogic.UpdateDoctor(DoctorToUpdate);

            // Assert
            _mockRepository.Verify(repo => repo.UpdateDoctor(It.Is<Doctor>(cb => cb.DoctorId == 1 && cb.Name == "UpdatedDoctor ")), Times.Once);
        }
        [Test]
        public void Update_InvalidIdDoctor()
        {
            // Arrange
            var invalidDoctor = new Doctor { DoctorId = 0, Name = "InvalidDoctor" };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => doctorLogic.UpdateDoctor(invalidDoctor));
            Assert.That(ex.Message, Is.EqualTo("Invalid Doctor ID."));
        }

    }
}
