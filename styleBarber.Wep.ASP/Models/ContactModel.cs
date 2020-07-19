using AutoMapper;
using styleBarber.Wep.ASP.Dao;
using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Models
{
    public class ContactModel
    {
        private ContactDao _db = null;
        private const string contactKey = "contat";
        private bool _isModified = true;
        private IMapper _mapper = null;
        public ContactModel()
        {
            _db = new ContactDao();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactVM>()
                    .ForMember(des => des.Name, act => act.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                    .ForMember(des => des.Phone, act => act.MapFrom(src => src.User.Phone))
                    .ForMember(des => des.Email, act => act.MapFrom(src => src.User.Email))
                    .ForMember(des => des.Image, act => act.MapFrom(src => src.User.Image))
                    .ForMember(des => des.Job, act => act.MapFrom(src => src.User.Job));
                cfg.CreateMap<ContactVM, Contact>();
            }).CreateMapper();
        }

        private List<ContactVM> GetData()
        {
            _isModified = false;
            var rawData = _db.GetContacts();
            List<ContactVM> contactVMs = new List<ContactVM>();
            if (rawData.Count == 0) return contactVMs;
            foreach (var item in rawData)
                contactVMs.Add(_mapper.Map<ContactVM>(item));
            DataCache.SetInCache(contactKey, contactVMs);
            return contactVMs;
        }

        public List<ContactVM> GetContactVMs()
        {
            if (_isModified)
                return GetData();
            var data = DataCache.GetInCache<List<ContactVM>>(contactKey);
            if (data == null)
                return GetData();
            return data;
        }

        public void Add(ContactVM contactVM)
        {
            if (contactVM == null) return;
            _isModified = true;
            _db.Add(_mapper.Map<Contact>(contactVM));
        }

    }
    public class ContactVM
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Review { get; set; }
        public string UserID { get; set; }
    }
}