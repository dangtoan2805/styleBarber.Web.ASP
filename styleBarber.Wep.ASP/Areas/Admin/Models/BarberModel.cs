using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Areas.Admin.Models
{
    public class BarberModel
    {
        private BarberContext _context = new BarberContext();

        public BarberModel() { }

        public List<Barber> GetListBarbers()
        {
            List<Barber> data = _context.Barbers.ToList();
            return data;
        }
        public List<Barber> TimTen(string ten)
        {
            List<Barber> name = _context.Barbers.Where(c => c.Name == ten).ToList();
            return name;
        }
        public List<Barber> Filters(int level)
        {
            List<Barber> fil = new List<Barber>();
            switch (level)
            {
                case 0:
                    fil = _context.Barbers.ToList();
                    break;
                case 1:
                    fil = _context.Barbers.Where(c => c.isFounder == true).ToList();
                    break;
                case 2:
                    fil = _context.Barbers.Where(c => c.isFounder == false).ToList();
                    break;
            }
            return fil;
        }
        public void ThemNV(Barber barber)
        {
            _context.Barbers.Add(new Barber { Name = barber.Name, Info = barber.Info, Email = barber.Email, LinkFB = barber.LinkFB, Twitter = barber.Twitter });
            _context.SaveChanges();

        }
        public void XoaNV(int ID)
        {
            var bar = _context.Barbers.Find(ID);

            _context.Barbers.Remove(bar);
            _context.SaveChanges();
        }
        public Barber XemNV(int ID)
        {
            var bar = _context.Barbers.Find(ID);
            return bar;
        }
        public void SuaNV(int ID, Barber barber)
        {
            var bar = _context.Barbers.Find(ID);
            bar.Name = barber.Name;
            bar.Info = barber.Info;
            bar.Email = barber.Email;
            bar.LinkFB = barber.LinkFB;
            bar.Twitter = barber.Twitter;
            _context.SaveChanges();

        }
    }
}