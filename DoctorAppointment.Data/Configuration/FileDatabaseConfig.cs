using Newtonsoft.Json;
using System.IO;

namespace MyDoctorAppointment.Data.Configuration
{
    public class FileDatabaseConfig
    {
        public string Root { get; }

        // JSON
        public string Doctors => Path.Combine(Root, "doctors.json");
        public string Patients => Path.Combine(Root, "patients.json");
        public string Appointments => Path.Combine(Root, "appointments.json");

        // XML
        public string DoctorsXml => Path.Combine(Root, "doctors.xml");
        public string PatientsXml => Path.Combine(Root, "patients.xml");
        public string AppointmentsXml => Path.Combine(Root, "appointments.xml");

        public FileDatabaseConfig()
        {
            var cfg = JsonConvert.DeserializeObject<dynamic>(
                File.ReadAllText(Constants.AppSettingsPath));

            Root = cfg.Database.Root;

            Directory.CreateDirectory(Root);
        }
    }
}
