using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace styleBarber.Wep.ASP.Entities
{
    public class Calendar
    {
        [Key]
        public int ID { get; set; }       
        [MaxLength(15)]
        public string Time { get; set; }
        //Nav 
        public ICollection<Appointment> Appointments { get; set; }
    }
}