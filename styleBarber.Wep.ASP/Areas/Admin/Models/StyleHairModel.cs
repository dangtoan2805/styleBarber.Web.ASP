using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace styleBarber.Wep.ASP.Areas.Admin.Models
{
    public class StyleHairModel
    {
        private BarberContext _context = new BarberContext();
        public StyleHairModel() { }
        public List<StyleHair> GetStyleHairs()
        {
            List<StyleHair> data = _context.StyleHair.ToList();
            return data;
        }
        public List<StyleHair> TimTen(string ten)
        {
            List<StyleHair> name = _context.StyleHair.Where(c => c.Title == ten).ToList();
            return name;
        }
        public void ThemKT(StyleHair stylehair)
        {
            _context.StyleHair.Add(new StyleHair { Title = stylehair.Title, StyleDescription = stylehair.StyleDescription });
            _context.SaveChanges();
        }
        public void XoaKT(int ID)
        {
            var sty = _context.StyleHair.Find(ID);

            _context.StyleHair.Remove(sty);
            _context.SaveChanges();
        }
        public StyleHair XemKT(int ID)
        {
            var sty = _context.StyleHair.Find(ID);
            return sty;
        }
        public void SuaKT(int ID, StyleHair stylehair)
        {
            var sty = _context.StyleHair.Find(ID);
            sty.Title = stylehair.Title;
            sty.StyleDescription = stylehair.StyleDescription;


            _context.SaveChanges();
        }
    }
}