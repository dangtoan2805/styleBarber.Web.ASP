using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace styleBarber.Wep.ASP.Entities
{
    public class Barber
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool LevelJob { get; set; }
        [MaxLength(25)]
        public string Image { get; set; }
        [MaxLength(350)]
        public string Info { get; set; }
        [MaxLength(100)]
        public string LinkFB { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Twiter { get; set; }
        //Nav 
        public ICollection<Calendar> Calendars { get; set; }
    }
}