using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        // Можна додати нові специфічні методи
    }
}
