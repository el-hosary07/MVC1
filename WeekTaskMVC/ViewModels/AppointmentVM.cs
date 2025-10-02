namespace WeekTaskMVC.ViewModels
{
    public class AppointmentVM
    {
        
        public List<Doctor> Doctors { get; set; }


        public int DoctorId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateOnly AppointDate { get; set; }
        public TimeOnly AppointTime { get; set; }
        
    }
}
