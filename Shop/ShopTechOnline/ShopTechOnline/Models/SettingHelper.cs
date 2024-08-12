using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models
{
    public class SettingHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static string GetValue(string key)
        {
            var item = db.systemSettings.SingleOrDefault(x => x.SettingKey == key);
            if(item != null)
            {
                return item.SettingValue;
            }
            return "";
        } 
    }
}