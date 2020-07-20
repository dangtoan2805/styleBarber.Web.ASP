using AutoMapper;
using styleBarber.Wep.ASP.Dao;
using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Helper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace styleBarber.Wep.ASP.Models
{
    public class BarberModel
    {
        private const string barberKey = "barber";
        private IMapper _mapper = null;
        private BarberDao _db = null;
        private bool isModified = true;

        public BarberModel()
        {
            var config = new MapperConfiguration(cfg => 
            { 
                cfg.CreateMap<Barber, BarberVM>();
                cfg.CreateMap<BarberVM, Barber>();
            });
            _mapper = config.CreateMapper();
            _db = new BarberDao();
        }

        private List<BarberVM> GetData()
        {
            isModified = false;
            var rawData = _db.GetBarbers();
            List<BarberVM> barberVMs = new List<BarberVM>();
            if (rawData.Count == 0) return barberVMs;
            foreach (var item in rawData)
                barberVMs.Add(_mapper.Map<BarberVM>(item));
            DataCache.SetInCache(barberKey, barberVMs);
            return barberVMs;
        }

        public List<BarberVM> GetBarberVMs() 
        {
            if (isModified)
                return GetData();
            var data = DataCache.GetInCache<List<BarberVM>>(barberKey);
            if (data != null)
                return data;
            else
                return GetData();
        }

        public List<BarberVM> Filter(bool level)
        {
            return GetBarberVMs().Where(item => item.isFounder == level).ToList();
        }


        public List<BarberVM> Find(string name) 
        {
            return GetBarberVMs().FindAll(item => item.Name.Contains(name));
        }


        
        public BarberVM Detail(int id) 
        {
            if (id == 0) return new BarberVM();
            var data = DataCache.GetInCache<List<BarberVM>>(barberKey);
            if (data != null)
                return data.Find(item => item.ID == id);
            var rawData = _db.FindByID(id);
            if (rawData == null) 
                return new BarberVM();
            return _mapper.Map<BarberVM>(rawData);
        }
       
        public void AddBarber(BarberVM barber) 
        {
            if (barber == null) return;
            isModified = true;
            _db.Add(_mapper.Map<Barber>(barber));
        }

        public void Delete(int id) 
        {
            if (id == 0) return;
            isModified = true;
            _db.Delete(id);
        }

        public void Update(int id, BarberVM barber) 
        {
            if (id == 0 || barber == null) return;
            isModified = true;
            _db.Update(id, _mapper.Map<Barber>(barber));
        }
    }

    public class BarberVM
    { 
        public int ID { get; set; }
        [Required(ErrorMessage = "Required enter Name")]
        public string Name { get; set; }
        public bool isFounder { get; set; }
        [Required(ErrorMessage = "Required upload Image")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Required enter Infomation")]
        public string Info { get; set; }
        public string LinkFB { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
    }
    

}