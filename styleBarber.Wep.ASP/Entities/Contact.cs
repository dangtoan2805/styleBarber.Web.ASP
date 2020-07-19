using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace styleBarber.Wep.ASP.Entities
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(350)]
        public string Review { get; set; } 
        //
        [ForeignKey("User")]
        public int? UserID { get; set; }
        //Nav
        public User User { get; set; }
    }
}