using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctorAppointment.Data.Configuration
{
    public class FileDatabaseConfig
    {
        public string Root { get; }
        public string Doctors => Path.Combine(Root, "doctors.json");
        public string Patients => Path.Combine(Root, "patients.json");
        public string Appointments => Path.Combine(Root, "appointments.json");

        public FileDatabaseConfig()
        {
            var cfg = JsonConvert.DeserializeObject<dynamic>(
                File.ReadAllText(Constants.AppSettingsPath));

            Root = cfg.Database.Root;
        }
    }

}
