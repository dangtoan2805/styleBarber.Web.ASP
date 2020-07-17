using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System.Collections.Generic;
using System.Linq;

namespace styleBarber.Wep.ASP.Dao
{
    public class StyleHairDao
    {
        private BarberContext _context = null;

        public StyleHairDao()
        {
            _context = new BarberContext();
        }

        public List<StyleHair> GetStyleHair() 
        {
            return _context.StyleHair.ToList();
        }

        public StyleHair FindByID(int id) 
        {
            return _context.StyleHair.Find(id);
        }

        public void Add(StyleHair styleHair) 
        {
            _context.StyleHair.Add(styleHair);
            _context.SaveChanges();
        }

        public void Update(int id, StyleHair styleHair) 
        {
            var hair = _context.StyleHair.Find(id);
            if (hair == null) return;
            hair.Image = styleHair.Image;
            hair.StyleDescription = styleHair.StyleDescription;
            hair.Title = styleHair.Title;
            _context.SaveChanges();
        }

        public void Delete(int id) 
        {
            var hair = _context.StyleHair.Find(id);
            if (hair == null) return;
            _context.StyleHair.Remove(hair);
            _context.SaveChanges();
        }
    }
}