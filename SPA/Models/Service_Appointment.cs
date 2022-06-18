namespace SPA.Models
{ 
     /// <summary>
     /// Klasa pośrednia - wizyta oraz usługa
     /// </summary>
    public class Service_Appointment
    {
        /// <value>
        /// Atrybut ID - klucz
        /// </value>
        public int ServiceId { get; set; }
        /// <value>
        /// Atrybut usługa
        /// </value>
        public Service Service { get; set; }
        /// <value>
        /// Atrybut ID usługi
        /// </value>
        public int AppointmentId { get; set; }
        /// <value>
        /// Atrybut wizyta
        /// </value>
        public Appointment Appointment { get; set; }
    }

}
