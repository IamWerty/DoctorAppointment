using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctorAppointment.Data.Models
{
    public class JsonTable<T>
    {
        public int LastId { get; set; } = 0;
        public List<T> Items { get; set; } = new();
    }

}
