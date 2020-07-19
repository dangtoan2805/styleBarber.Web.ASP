using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [MaxLength(50)]
        public string Job { get; set; }
        //Nav
        public List<Contact> Contacts { get; set; }
    }
}