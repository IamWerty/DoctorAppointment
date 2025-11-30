namespace MyDoctorAppointment.Domain.Enums
{
    public enum MenuAction
    {
        Exit = 0, // Нумерація потрібна для зручності помітки в меню
        ListDoctors = 1,
        AddDoctor = 2,
        DeleteDoctor = 3,
        UpdateDoctor = 4,

        ListPatients = 5,
        AddPatient = 6,
        DeletePatient = 7,
        UpdatePatient = 8,

        ListAppointments = 9,
        AddAppointment = 10, 
        DeleteAppointment = 11
    }

}
