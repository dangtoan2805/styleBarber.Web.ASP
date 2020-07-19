using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;

namespace styleBarber.Wep.ASP.Dao
{
    public class AppoimentDao
    {
        private BarberContext _context = null;
        public AppoimentDao()
        {
            _context = new BarberContext();
        }

        public List<Appointment> GetAppointments()
        {
            return _context.Appointments
                .Include(item => item.Barber)
                .Include(item => item.User)
                .ToList();
        }

        public object GetTopBarbers()
        {
            return _context.Appointments
                .Include(item => item.Barber)
                .GroupBy(item => new { item.BarberID, item.Barber.Name })
                .Select(item => new 
                { 
                    Barber = item.Key.Name, 
                    Count = item.Count() 
                })
                .OrderByDescending(item => item.Count)
                .Take(5).ToList();
        }

        public int Count()
        {
            return _context.Appointments.Count();
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChangesAsync();
        }

        public void UpdateStatus(int id, bool  status)
        {
            var data = _context.Appointments.Find(id);
            if (data == null) return;
            data.Status = status;
            _context.SaveChangesAsync();
        }

    }
}