using System.ComponentModel.DataAnnotations;

namespace styleBarber.Wep.ASP.Entities
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int Phone { get; set; }
        [MaxLength(350)]
        public string Note { get; set; }
    }
}