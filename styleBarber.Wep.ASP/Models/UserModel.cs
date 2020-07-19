using AutoMapper;
using styleBarber.Wep.ASP.Dao;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace styleBarber.Wep.ASP.Models
{
    public class UserModel
    {
        private UserDao _db = null;
        private IMapper _mapper = null;
        public UserModel()
        {
            _db = new UserDao();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserVM>()
                   .ForMember(des => des.Name, act => act.MapFrom(src => src.FirstName + " " + src.LastName));
                cfg.CreateMap<UserVM, User>();
            }).CreateMapper();
        }

        public int UserLogin(string email, string pass)
        {
            var obj =  _db.CheckUser(email, pass);
            if (obj == null) return -1;
            UserVM user = _mapper.Map<UserVM>(obj);
            FormsAuthentication.SetAuthCookie(user.ID.ToString(), false);
            return obj.isAdmin ? 0: 1;
        }

        public UserVM GetUser(int id)
        {
            if (id == 0)
                return new UserVM();
            var obj = _db.FindUserByID(id);
            if (obj == null)
                return new UserVM();
            return _mapper.Map<UserVM>(obj);
        }

        public void UserLogout()
        {
            FormsAuthentication.SignOut();
        }

        public void AddUser(UserVM userVM, string pass)
        {
            if (userVM == null) return;
            User user = _mapper.Map<User>(userVM);
            user.Password = pass;
            _db.AddUser(user);
        }

    }
    public class UserVM
    {   
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Job { get; set; }
    }


}