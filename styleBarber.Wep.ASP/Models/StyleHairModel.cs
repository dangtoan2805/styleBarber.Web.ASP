using AutoMapper;
using styleBarber.Wep.ASP.Dao;
using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace styleBarber.Wep.ASP.Models
{
    public class StyleHairModel
    {
        private const string hairKey = "hair";
        private StyleHairDao _db = null;
        private bool isModified = true;
        private IMapper _mapper = null;
        public StyleHairModel()
        {
            _db = new StyleHairDao();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StyleHairVM, StyleHair>();
                cfg.CreateMap<StyleHair, StyleHairVM>();
            }).CreateMapper();
        }

        private List<StyleHairVM> GetData() 
        {
            isModified = false;
            var rawData = _db.GetStyleHair();
            List<StyleHairVM> styleHairVMs = new List<StyleHairVM>();
            if (rawData.Count == 0) return styleHairVMs;
            foreach (var item in rawData)
                styleHairVMs.Add(_mapper.Map<StyleHairVM>(item));
            DataCache.SetInCache(hairKey, styleHairVMs);
            return styleHairVMs;
        }

        public List<StyleHairVM> GetStyleHairVMs()
        {
            if (isModified) 
                return GetData();
            var data = DataCache.GetInCache<List<StyleHairVM>>(hairKey);
            if (data != null) 
                return data;
            else
                return GetData();
        }

        public List<StyleHairVM> Find(string key)
        {
            return GetStyleHairVMs().FindAll(item => item.Title.Contains(key));
        }

        public StyleHairVM Detail(int id) 
        {
            if (id == 0) return new StyleHairVM();
            var data = DataCache.GetInCache<List<StyleHairVM>>(hairKey);
            if (data != null)
                return data.Find(item => item.ID==id);
            var rawData = _db.FindByID(id);
            if(rawData == null)
                return new StyleHairVM();
            return _mapper.Map<StyleHairVM>(rawData);

        }


        public void AddStyleHair(StyleHairVM styleHairVM)
        {
            if (styleHairVM == null) return;
            isModified = true;
            _db.Add(_mapper.Map<StyleHair>(styleHairVM));
        }

        public void Udpdate(int id,StyleHairVM styleHairVM)
        {
            if (id==0 || styleHairVM == null) return;
            isModified = true;
            _db.Update(id,_mapper.Map<StyleHair>(styleHairVM));
        }

        public void Delete(int id)
        {
            if (id == 0) return;
            isModified = true;
            _db.Delete(id);
        }




    }

    public class StyleHairVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string StyleDescription { get; set; }
    }
}