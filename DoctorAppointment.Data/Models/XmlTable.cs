using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Data.Models
{
    [XmlRoot("Table")]
    public class XmlTable<T>
    {
        [XmlElement("LastId")]
        public int LastId { get; set; } = 0;

        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<T> Items { get; set; } = new();
    }
}
