using System.Xml.Serialization;

namespace MyDoctorAppointment.Domain.Entities
{
    public abstract class Auditable
    {
        public int Id { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? CreatedAt { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? UpdatedAt { get; set; }

    }
}
