using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace styleBarber.Wep.ASP.Entities
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string Phone { get; set; }
        [MaxLength(350)]
        public string Note { get; set; }
        [DefaultValue(false)]
        public bool Status { get; set; }
        //Frogien Key
        [ForeignKey("Barber")]
        public int BarberID { get; set; }
        //Nav
        public Barber Barber { get; set; }
    }
}