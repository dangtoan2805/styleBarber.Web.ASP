using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Models
{
    public class ServiceModel
    {
        private BarberContext _context = new BarberContext();
        public ServiceModel() { }
        public List<Service> GetAllServices()
        {
            List<Service> ser = _context.Services.ToList();
            return ser;
        }
        public List<Barber> GetAllBarbers()
        {
            List<Barber> bar = _context.Barbers.ToList();
            return bar;
        }


    }
}