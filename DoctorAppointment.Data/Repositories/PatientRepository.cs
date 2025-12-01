using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(FileDatabaseConfig config) : base(config.Patients, config.PatientsXml)
        {
        }

        public override void ShowInfo(Patient p)
        {
            Console.WriteLine("---- Patient Info ----");
            Console.WriteLine($"ID: {p.Id}");
            Console.WriteLine($"Name: {p.Name} {p.Surname}");
            Console.WriteLine($"Age: {p.Age}");
            Console.WriteLine($"Phone: {p.Phone}");
        }
    }
}
