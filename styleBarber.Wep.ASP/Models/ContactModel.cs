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
                cfg.CreateMap<Contact, ContactVM>();
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}