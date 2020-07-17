using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Dao
{
    public class BarberDao
    {
        private BarberContext _context = null;

        public BarberDao()
        {
            _context = new BarberContext();
        }

        public List<Barber> GetBarbers() 
        {
            return _context.Barbers.ToList();
        }

        public Barber FindByID(int id)
        {
            return _context.Barbers.Where(item => item.ID == id).FirstOrDefault();
        }

        public void Add(Barber barber)
        {
            _context.Barbers.Add(barber);
            _context.SaveChanges();
        }

        public void Update (int ID, Barber barber)
        {
            var bar = _context.Barbers.Find(ID);
            if (bar == null) return;
            bar.Name = barber.Name;
            bar.Info = barber.Info;
            bar.Email = barber.Email;
            bar.LinkFB = barber.LinkFB;
            bar.Twitter = barber.Twitter;
            _context.SaveChanges();
        }

        public void Delete(int ID)
        {
            var bar = _context.Barbers.Find(ID);
            if (bar == null) return;
            _context.Barbers.Remove(bar);
            _context.SaveChanges();
        }
        
           }
}