using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService()
        {
            _repo = new AppointmentRepository();
        }

        public Appointment Create(Appointment appointment) => _repo.Create(appointment);
        public bool Delete(int id) => _repo.Delete(id);
        public Appointment? Get(int id) => _repo.GetById(id);
        public IEnumerable<Appointment> GetAll() => _repo.GetAll();
        public Appointment Update(int id, Appointment a) => _repo.Update(id, a);
    }
}
