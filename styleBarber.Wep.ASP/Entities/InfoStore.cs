using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Entities
{
    public class InfoStore
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(25)]
        public string Logo { get; set; }
        [MaxLength(350)]
        public string About { get; set; }
        [MaxLength(350)]
        public string Mission { get; set; }
        [MaxLength(350)]
        public string Reason { get; set; }
        
    }
}