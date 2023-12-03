using G6RXAI_ADT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace G6RXAI_ADT_2023241.Repository
{
    public class HospitalAppointmentDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder Build)
        {
            Build


                .UseInMemoryDatabase("HospitalDatabase")
                .UseLazyLoadingProxies();
            base.OnConfiguring(Build);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // one-to-many relationship between Doctor  and Patient
            modelBuilder.Entity<Models.Patient>()
                .HasOne(patient => patient.Doctor)
                .WithMany(doctor => doctor.Patients)
                .HasForeignKey(patient => patient.DoctorId);

            //  one-to-many relationship between Doctor  and Appointment 
            modelBuilder.Entity<Models.Appointment>()
                .HasOne(appointment => appointment.Doctor)
                .WithMany(doctor => doctor.Appointments)
                .HasForeignKey(appointment => appointment.DoctorId);

            //  one-to-many relationship between Patient  and Appointment 
            modelBuilder.Entity<Models.Appointment>()

                .HasOne(appointment => appointment.Patient)
                .WithMany(patient => patient.Appointments)
                .HasForeignKey(appointment => appointment.PatientId);

            base.OnModelCreating(modelBuilder);
             

            // ADDING THE SEED DATA 
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {DoctorId=402 ,Specialization="Internist", Name = "Frederick Cruz" },
                new Doctor {DoctorId=403 ,Specialization="Gynaecologist", Name = "Gary Harkov" },
                new Doctor {DoctorId=404 ,Specialization="Surgery", Name = "Gary Harkov" }

            );

            
            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1001, Name = "John Smith", DoctorId = 403,BirthDate =    DateTime.Parse("1999-08-24")},
                new Patient { PatientId = 1002, Name = "Farida Gayyr",   DoctorId = 402,BirthDate =DateTime.Parse("1974-05-05")},
                new Patient { PatientId = 1003, Name = "Haffez Jury",   DoctorId = 401,BirthDate =DateTime.Parse("2007-08-21")},
                new Patient { PatientId = 1004, Name = "Fabby Thomas", DoctorId = 402, BirthDate =  DateTime.Parse("2020-09-30")}
            );                                                                                  

   
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { AppointmentId = 610, AppointmentDate = DateTime.Parse("2023-12-01"),DoctorId= 401, PatientId = 1003 },
                new Appointment { AppointmentId = 723, AppointmentDate = DateTime.Parse("2023-04-02"),DoctorId= 402, PatientId = 1001 }
          );                                                                                   


        }
    }
}
