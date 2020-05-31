using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace styleBarber.Wep.ASP.Entities
{
    public class Calendar
    {
        [Key]
        public int ID { get; set; }       
        [MaxLength(15)]
        public string Date { get; set; }
        [MaxLength(15)]
        public string Time { get; set; }
        public int BarberID { get; set; }
        //Nav 
        public Barber Barber { get; set; }
        public Appointment Appointment { get; set; }
    }
}