using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(FileDatabaseConfig config)
        {
            _doctorRepository = new DoctorRepository(new FileDatabaseConfig());
        }

        public Doctor Create(Doctor doctor) => _doctorRepository.Create(doctor);
        public bool Delete(int id) => _doctorRepository.Delete(id);
        public Doctor? Get(int id) => _doctorRepository.GetById(id);
        public IEnumerable<Doctor> GetAll() => _doctorRepository.GetAll();
        public Doctor Update(int id, Doctor doctor) => _doctorRepository.Update(id, doctor);
    }

}
