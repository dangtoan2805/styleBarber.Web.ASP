using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System.Collections.Generic;
using System.Linq;

namespace styleBarber.Wep.ASP.Dao
{
    public class ServiceDao
    {
        private BarberContext _context = null;

        public ServiceDao()
        {
            _context = new BarberContext();
        }

        public List<Service> GetServices() 
        {
            return _context.Services.ToList();
        }

        public Service FindByID(int id)
        {
            return _context.Services
                .Where(item => item.ID == id)
                .FirstOrDefault();
        }

        public void Add(Service service) 
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Udpate(int id, Service service)
        {
            var ser = _context.Services.Find(id);
            if (ser == null) return;
            ser.Name = service.Name;
            ser.ServiceDescription = service.ServiceDescription;
            ser.Price = service.Price;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ser = _context.Services.Find(id);
            if (ser == null) return;
            _context.Services.Remove(ser);
            _context.SaveChanges();
        }
    }
}