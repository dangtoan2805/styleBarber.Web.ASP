using System.ComponentModel.DataAnnotations;

namespace styleBarber.Wep.ASP.Entities
{
    public class StyleHair
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(25)]
        public string Image { get; set; }
        [MaxLength(350)]
        public string Content { get; set; }
    }
}