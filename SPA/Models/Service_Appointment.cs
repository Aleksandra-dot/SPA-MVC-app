namespace SPA.Models
{
    public class Service_Appointment
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }   

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }

}
