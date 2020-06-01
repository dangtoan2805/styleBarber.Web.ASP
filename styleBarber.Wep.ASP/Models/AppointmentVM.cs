using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Models
{
    public class AppointmentVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
    }
}