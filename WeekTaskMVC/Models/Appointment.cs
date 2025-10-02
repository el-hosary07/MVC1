
namespace WeekTaskMVC.Models
{
    public class Appointment
    {
        public Appointment()
        {
        }

        public Appointment(string patientName, DateOnly appointmentDate, TimeOnly appointmentTime, int doctorId)
        {
            Id = 0;
            PatientName = patientName;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            DoctorId = doctorId;
        }

        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public int DoctorId { get; set; }
    }
}
