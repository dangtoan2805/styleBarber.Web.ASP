using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Areas.Admin.Models
{
    public class ServiceModel
    {
        private BarberContext _context = new BarberContext();
        public ServiceModel() { }
        public List<Service> GetServices()
        {
            List<Service> data  = _context.Services.ToList();
            return data;
        }
        public List<Service> TimTen(string ten)
        {
            List<Service> name = _context.Services.Where(c => c.Name == ten).ToList();
            return name;
        }
        public void ThemDV(Service service)
        {
            _context.Services.Add(new Service { Name = service.Name, ServiceDescription = service.ServiceDescription, Price = service.Price });
            _context.SaveChanges();
        }
        public void XoaDV(int ID)
        {
            var ser = _context.Services.Find(ID);

            _context.Services.Remove(ser);
            _context.SaveChanges();
        }
        public Service XemDV(int ID)
        {
            var ser = _context.Services.Find(ID);
            return ser;
        }
        public void SuaDV(int ID, Service service)
        {
            var ser = _context.Services.Find(ID);
            ser.Name = service.Name;
            ser.ServiceDescription = service.ServiceDescription;
            ser.Price = service.Price;

            _context.SaveChanges();
        }
    }
}