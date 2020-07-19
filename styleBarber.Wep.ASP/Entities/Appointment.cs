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
        public string Note { get; set; }
        //Frogien Key
        public bool Status { get; set; }
        [ForeignKey("User")]
        public int? UserID {get;set;}
        [ForeignKey("Barber")]
        public int? BarberID { get; set; }
        //Nav
        public Barber Barber { get; set; }
        public User User { get; set; }
    }
}