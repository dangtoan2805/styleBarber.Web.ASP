using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Dao
{
    public class UserDao
    {
        private BarberContext _context = null;
        public UserDao()
        {
            _context = new BarberContext();
        }

        public User FindUserByID(int id)
        {
            return _context.Users.Find(id);
        }
        
        public User CheckUser(string email, string pass)
        {
            return _context.Users
                .Where(item => item.Email == email && item.Password == pass)
                .FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChangesAsync();
        }

        public void Update(User user)
        {

        }




    }
}