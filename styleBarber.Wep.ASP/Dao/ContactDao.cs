using Microsoft.AspNetCore.Razor.Language;
using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Dao
{
    public class ContactDao
    {
        private BarberContext _context = null;
        public ContactDao()
        {
            _context = new BarberContext();
        }

        public List<Contact> GetContacts()
        {
            return _context.Contacts
                .Include(item => item.User)
                .ToList();
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChangesAsync();
        }
    }
}