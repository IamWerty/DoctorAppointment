using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository()
        {
            dynamic config = ReadFromAppSettings();

            Path = config.Database.Appointments.Path;
            LastId = config.Database.Appointments.LastId;
        }

        public override void ShowInfo(Appointment a)
        {
            Console.WriteLine("---- Appointment Info ----");
            Console.WriteLine($"ID: {a.Id}");
            Console.WriteLine($"DoctorId: {a.Doctor.DoctorId}");
            Console.WriteLine($"PatientId: {a.Patient.PatientId}");
            Console.WriteLine($"Date: {a.CreatedAt}");
            Console.WriteLine($"IllnessType: {a.Patient.IllnessType}");
            Console.WriteLine();
        }

        protected override void SaveLastId()
        {
            dynamic config = ReadFromAppSettings();
            config.Database.Appointments.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, config.ToString());
        }
    }
}
