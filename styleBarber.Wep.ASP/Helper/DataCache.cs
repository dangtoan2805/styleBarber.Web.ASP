using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace styleBarber.Wep.ASP.Helper
{
    public static class DataCache
    {
        public static T GetInCache<T>(string key) 
        {
            var data = HttpContext.Current.Cache.Get(key);
            return data == null ? default(T) : (T)data;
        }

        public static void SetInCache(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data,null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
        }
    }
}