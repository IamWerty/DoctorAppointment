using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService()
        {
            _repo = new PatientRepository();
        }

        public Patient Create(Patient patient) => _repo.Create(patient);
        public bool Delete(int id) => _repo.Delete(id);
        public Patient? Get(int id) => _repo.GetById(id);
        public IEnumerable<Patient> GetAll() => _repo.GetAll();
        public Patient Update(int id, Patient p) => _repo.Update(id, p);
    }
}
