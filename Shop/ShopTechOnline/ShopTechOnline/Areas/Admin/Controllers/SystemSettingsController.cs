using ShopTechOnline.Models;
using ShopTechOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Areas.Admin.Controllers
{
    // Cấu hình hệ thống

    public class SystemSettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/SystemSettings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partial_Setting()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddSetting(SettingSystemViewModel req)
        {
            // kiểm tra checktitle
            SystemSetting set = null;
            var checkTitle = db.systemSettings.FirstOrDefault(x => x.SettingKey.Contains("SettingTitle"));
            if ( checkTitle == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingTitle";
                set.SettingValue = req.SettingTitle;
                db.systemSettings.Add(set);
            }
            else
            {
                checkTitle.SettingValue = req.SettingTitle;
                db.Entry(checkTitle).State = System.Data.Entity.EntityState.Modified;
            }
            // kiểm tra checklogo
            var checkLogo = db.systemSettings.FirstOrDefault(x => x.SettingKey.Contains("SettingLogo"));
            if (checkLogo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingLogo";
                set.SettingValue = req.Settinglogo;
                db.systemSettings.Add(set);
            }
            else
            {
                checkLogo.SettingValue = req.Settinglogo;
                db.Entry(checkLogo).State = System.Data.Entity.EntityState.Modified;
            }
            // kiểm tra checkemail
            var checkEmail = db.systemSettings.FirstOrDefault(x => x.SettingKey.Contains("SettingEmail"));
            if (checkEmail == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingEmail";
                set.SettingValue = req.SettingEmail;
                db.systemSettings.Add(set);
            }
            else
            {
                checkEmail.SettingValue = req.SettingEmail;
                db.Entry(checkEmail).State = System.Data.Entity.EntityState.Modified;
            }
            // kiểm tra checkhotline
            var checkHotline = db.systemSettings.FirstOrDefault(x => x.SettingKey.Contains("SettingHotline"));
            if (checkHotline == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingHotline";
                set.SettingValue = req.SettingHotline;
                db.systemSettings.Add(set);
            }
            else
            {
                checkHotline.SettingValue = req.SettingHotline;
                db.Entry(checkHotline).State = System.Data.Entity.EntityState.Modified;
            }
            // kiểm tra Titleseo
            var Titleseo = db.systemSettings.FirstOrDefault(x => x.SettingKey.Contains("SettingTitleSeo"));
            if (Titleseo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingTitleSeo";
                set.SettingValue = req.SettingTitleSeo;
                db.systemSettings.Add(set);
            }
            else
            {
                Titleseo.SettingValue = req.SettingTitleSeo;
                db.Entry(Titleseo).State = System.Data.Entity.EntityState.Modified;
            }
            // kiểm tra DesSeo
            var DesSeo = db.systemSettings.FirstOrDefault(x => x.SettingKey.Contains("SettingDesSeo"));
            if (DesSeo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingDesSeo";
                set.SettingValue = req.SettingDesSeo;
                db.systemSettings.Add(set);
            }
            else
            {
                DesSeo.SettingValue = req.SettingDesSeo;
                db.Entry(DesSeo).State = System.Data.Entity.EntityState.Modified;
            }
            // kiểm tra KeySeo
            var KeySeo = db.systemSettings.FirstOrDefault(x => x.SettingKey.Contains("SettingKeySeo"));
            if (KeySeo == null)
            {
                set = new SystemSetting();
                set.SettingKey = "SettingKeySeo";
                set.SettingValue = req.SettingKeySeo;
                db.systemSettings.Add(set);
            }
            else
            {
                KeySeo.SettingValue = req.SettingKeySeo;
                db.Entry(KeySeo).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return View("Partial_Setting");
        }
    }
}