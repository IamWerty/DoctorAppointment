using System.Xml.Serialization;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Appointment : Auditable
    {
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? CreatedAt { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? UpdatedAt { get; set; }

        public string? Description { get; set; }
    }
}
