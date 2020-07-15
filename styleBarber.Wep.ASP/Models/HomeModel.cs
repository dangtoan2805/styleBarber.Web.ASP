using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace styleBarber.Wep.ASP.Models
{
    public class HomeModel
    {
        private BarberContext _context = new BarberContext();
        public HomeModel() { }
        public InfoStore info()
        {
            var Info = _context.InfoStores.FirstOrDefault();   
            return Info;
        }
        public List<StyleHair> GetStyleHairs()
        {
            List<StyleHair> sty = _context.StyleHair.Take(3).ToList();
            return sty;
        }
        public List<Service> GetServices()
        {
            List<Service> ser = _context.Services.ToList();
            return ser;
        }
        public List<Barber> GetBarbers()
        {
            List<Barber> bar = _context.Barbers.Take(3).ToList();
            return bar;
        }
        public List<Reviewer> GetReviewers()
        {
            List<Reviewer> rev = _context.Reviewers.ToList();
            return rev;
        }
    }
}