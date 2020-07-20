using AutoMapper;
using styleBarber.Wep.ASP.Dao;
using styleBarber.Wep.ASP.Entities;
using System.ComponentModel.DataAnnotations;
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
                cfg.CreateMap<User, UserVM>();
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

        public bool CheckEmail(string email)
        {
           return  !_db.CheckEmail(email);
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

        public void ChangePassword(int id, string pass)
        {
            if (id == 0) return;
           _db.Update(id, pass);
        }

    }
    public class UserVM
    {   
        public int ID { get; set; }
        [Required(ErrorMessage = "Required enter LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required enter FirstName")]
        public string FirstName { get; set; }
        [StringLength(11,MinimumLength =10,ErrorMessage ="Phone number is 10 or 11 numbers")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Required enter Email")]
        public string Email { get; set; }
        public string Image { get; set; }
        public string Job { get; set; }
    }


}