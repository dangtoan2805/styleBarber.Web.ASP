using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace styleBarber.Wep.ASP.Entities
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(15)]
        public string Date { get; set; }
        //Frogien Key
        [ForeignKey("Barber")]
        public int BarberID { get; set; }
        [ForeignKey("Calendar")]
        public int CalendarID { get; set; }
        //Nav
        public Barber Barber { get; set; }
        public Calendar Calendar { get; set; }
    }
}