using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(FileDatabaseConfig config) : base(config.Appointments)
        {
        }

        public override void ShowInfo(Appointment a)
        {
            Console.WriteLine("---- Appointment Info ----");
            Console.WriteLine($"ID: {a.Id}");
            Console.WriteLine($"DoctorId: {a.Doctor.DoctorId}");
            Console.WriteLine($"PatientId: {a.Patient.PatientId}");
            Console.WriteLine($"Date: {a.CreatedAt}");
            Console.WriteLine($"IllnessType: {a.Patient.IllnessType}\n");
        }
    }
}
