﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Model
{
    public class ContactVM
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public int Phone { get; set; }

        public string Note { get; set; }
        public ContactVM()
        {
            
        }
    }
}