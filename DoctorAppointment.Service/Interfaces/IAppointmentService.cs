using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment Create(Appointment appointment);
        Appointment Update(int id, Appointment appointment);
        bool Delete(int id);
        Appointment? Get(int id);
        IEnumerable<Appointment> GetAll();
    }
}
