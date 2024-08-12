using ShopTechOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Parrtial_View_Home() 
        {
            var items = db.news.Take(3).ToList();
            return PartialView(items);
        }
    }
}