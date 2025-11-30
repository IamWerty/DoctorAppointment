using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
	public interface IPatientRepository : IGenericRepository<Patient>
	{
		// Тут можна додати специфічні методи (якщо треба)
	}
}
