using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System.Collections.Generic;
using System.Linq;

namespace styleBarber.Wep.ASP.Dao
{
    public class SettingDao
    {
        private BarberContext _context = null;
        public SettingDao()
        {
            _context = new BarberContext();
        }

        public InfoStore GetInfo()
        {
            return _context.InfoStores.FirstOrDefault();
        } 

        public void Update(InfoStore info)
        {
            var obj = _context.InfoStores.FirstOrDefault();
            if (obj == null) return;
            obj.About = info.About;
            obj.Logo = info.Logo;
            obj.Mission = info.Mission;
            _context.SaveChangesAsync();
        }

        public List<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }
    }

}