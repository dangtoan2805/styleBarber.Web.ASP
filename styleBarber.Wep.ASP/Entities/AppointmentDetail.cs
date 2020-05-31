using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Entities
{
    public class AppointmentDetail
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(25)]
        public string FisrtName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int Phone { get; set; }
        [MaxLength(350)]
        public string Note { get; set; }
        //Forgien Key
        public int AppointmentID { get; set; }
        //Nav
        public Appointment Appointment { get; set; }
    }
}