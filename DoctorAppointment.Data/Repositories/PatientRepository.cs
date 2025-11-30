using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository()
        {
            dynamic config = ReadFromAppSettings();

            Path = config.Database.Patients.Path;
            LastId = config.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine("---- Patient Info ----");
            Console.WriteLine($"ID: {patient.Id}");
            Console.WriteLine($"Name: {patient.Name} {patient.Surname}");
            Console.WriteLine($"Age: {patient.Age}");
            Console.WriteLine($"Phone: {patient.Phone}");
            Console.WriteLine();
        }

        protected override void SaveLastId()
        {
            dynamic config = ReadFromAppSettings();
            config.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, config.ToString());
        }
    }
}
