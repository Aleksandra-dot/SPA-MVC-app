using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Appointment:IEntityBase
    {
        /// <value>
        /// Atrybut ID wizyty - klucz główny
        /// </value>
        public int Id { get; set; }
        [Display(Name ="Date")]
        /// <value>
        /// Atrybut data wizyty
        /// </value>
        public DateTime Date { get; set; }

        /// <value>
        /// Relationships
        /// </value>

        public List<Service_Appointment> Service_Appointments { get; set; }

        /// <value>
        /// Relationships - ID pracownika - klucz obcy
        /// </value>

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [Display(Name = "Employee")]
        /// <value>
        /// Relationships - pracownik
        /// </value>
        public Employee Employee { get; set; }

        /// <value>
        /// Relationships - ID klienta - klucz obcy
        /// </value>

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        [Display(Name = "Client")]
        /// <value>
        /// Relationships - klient
        /// </value>

        public Client Client { get; set; }


    }
}
