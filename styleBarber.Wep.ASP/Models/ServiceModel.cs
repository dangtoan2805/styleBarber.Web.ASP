using AutoMapper;
using styleBarber.Wep.ASP.Dao;
using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Helper;
using System.Collections.Generic;

namespace styleBarber.Wep.ASP.Models
{
    public class ServiceModel
    {
        private const string serviceKey = "service";
        private ServiceDao _db = null;
        private IMapper _mapper = null;
        private bool isModified = true;

        public ServiceModel()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ServiceVM, Service>();
                cfg.CreateMap<Service, ServiceVM>();
            }).CreateMapper();
            _db = new ServiceDao();
        }

        private List<ServiceVM> GetData()
        {
            isModified = false;
            var rawData = _db.GetServices();
            List<ServiceVM> serviceVMs = new List<ServiceVM>();
            if (rawData.Count == 0) return serviceVMs;
            foreach (var item in rawData)
                serviceVMs.Add(_mapper.Map<ServiceVM>(item));
            DataCache.SetInCache(serviceKey, serviceVMs);
            return serviceVMs;
        }

        public List<ServiceVM> GetServiceVMs()
        {
            if (isModified)
                return GetData();
            var data = DataCache.GetInCache<List<ServiceVM>>(serviceKey);
            if (data != null)
                return data;
            else
                return GetData();
        }

        public List<ServiceVM> Find(string name)
        {
            return GetServiceVMs().FindAll(item => item.Name.Contains(name));
        }

        public ServiceVM Detail(int id)
        {
            if (id == 0) return new ServiceVM();
            var data = DataCache.GetInCache<List<ServiceVM>>(serviceKey);
            if (data != null)
                return data.Find(item => item.ID == id);
            var rawData = _db.FindByID(id);
            if (rawData == null) 
                return new ServiceVM();
            return _mapper.Map<ServiceVM>(rawData);
        }

        public void AddService(ServiceVM service)
        {
            if (service == null) return;
            isModified = true;
            _db.Add(_mapper.Map<Service>(service));
        }

        public void Delete(int id)
        {
            if (id == 0) return;
            isModified = true;
            _db.Delete(id);
        }

        public void Update(int id, ServiceVM service)
        {
            if (id == 0 || service == null) return;
            isModified = true;
            _db.Udpate(id, _mapper.Map<Service>(service));
        }

    }


    public class ServiceVM
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string ServiceDescription { get; set; }
        public int Price { get; set; }
    } 
}