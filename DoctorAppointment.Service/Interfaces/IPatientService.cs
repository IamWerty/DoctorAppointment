using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        Patient Update(int id, Patient patient);
        bool Delete(int id);
        Patient? Get(int id);
        IEnumerable<Patient> GetAll();
    }
}
