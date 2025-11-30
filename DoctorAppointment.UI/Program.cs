using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public DoctorAppointment()
        {
            var config = new FileDatabaseConfig();

            _doctorService = new DoctorService(config);
            _patientService = new PatientService(config);
            _appointmentService = new AppointmentService(config);
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n=== DOCTOR APPOINTMENT MENU ===");
                foreach (var val in Enum.GetValues<MenuAction>())
                    Console.WriteLine($"{(int)val}. {val}");

                Console.Write("Enter option: ");
                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                var action = (MenuAction)choice;

                switch (action)
                {
                    case MenuAction.Exit:
                        return;

                    case MenuAction.ListDoctors:
                        foreach (var d in _doctorService.GetAll())
                            Console.WriteLine($"{d.Id}. {d.Name} {d.Surname}");
                        break;

                    case MenuAction.AddDoctor:
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Surname: ");
                        var sur = Console.ReadLine();
                        Console.Write("Experience: ");
                        int exp = int.Parse(Console.ReadLine());

                        var doc = new Doctor
                        {
                            Name = name,
                            Surname = sur,
                            Experience = (byte)exp,
                            DoctorType = DoctorTypes.Dentist
                        };
                        _doctorService.Create(doc);
                        Console.WriteLine("Doctor added.");
                        break;

                    case MenuAction.DeleteDoctor:
                        Console.Write("Doctor ID: ");
                        int did = int.Parse(Console.ReadLine());
                        Console.WriteLine(_doctorService.Delete(did) ? "Deleted" : "Not found");
                        break;

                    case MenuAction.ListPatients:
                        foreach (var p in _patientService.GetAll())
                            Console.WriteLine($"{p.Id}. {p.Name} {p.Surname}");
                        break;

                    case MenuAction.AddPatient:
                        Console.Write("Name: ");
                        var pn = Console.ReadLine();
                        Console.Write("Surname: ");
                        var ps = Console.ReadLine();

                        var newP = new Patient { Name = pn, Surname = ps, Age = 30 };
                        _patientService.Create(newP);
                        Console.WriteLine("Patient added.");
                        break;

                    case MenuAction.ListAppointments:
                        foreach (var a in _appointmentService.GetAll())
                            Console.WriteLine($"#{a.Id}: Doctor {a.Doctor.Id} -> Patient {a.Patient.Id}");
                        break;

                    case MenuAction.AddAppointment:
                        Console.Write("Doctor ID: ");
                        var ad = int.Parse(Console.ReadLine());

                        Console.Write("Patient ID: ");
                        var ap = int.Parse(Console.ReadLine());

                        var appointment = new Appointment
                        {
                            Doctor = new Doctor { Id = ad },
                            Patient = new Patient { Id = ap },
                        };

                        _appointmentService.Create(appointment);
                        Console.WriteLine("Appointment created.");
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}
