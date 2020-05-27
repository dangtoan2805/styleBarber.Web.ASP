using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Entities
{
    public class Service
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(25)]
        public string Image { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(350)]
        public string ServiceDescription { get; set; }
        public int Price { get; set; }
    }
}