using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(FileDatabaseConfig config) : base(config.Doctors, config.DoctorsXml)
        {
        }

        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine("---- Doctor Info ----");
            Console.WriteLine($"ID: {doctor.Id}");
            Console.WriteLine($"Name: {doctor.Name} {doctor.Surname}");
            Console.WriteLine($"Experience: {doctor.Experience}");
            Console.WriteLine($"Salary: {doctor.Salary}");
            Console.WriteLine($"DoctorType: {doctor.DoctorType}");
        }
    }
}
