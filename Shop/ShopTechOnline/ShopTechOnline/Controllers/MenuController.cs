using ShopTechOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTop() 
        {
            var items = db.categories.OrderBy( x => x.Position ).ToList();
            return PartialView("_MenuTop",items);
        }

        public ActionResult MenuProductCategory()
        {
            var items = db.productCategories.ToList();
            return PartialView("_MenuProductCategory",items);
        }

        public ActionResult MenuLeft()
        {
            var items = db.productCategories.ToList();
            return PartialView("_MenuLeft", items);
        }

        public ActionResult MenuArrivals()
        {
            var items = db.productCategories.ToList();
            return PartialView("_MenuArrivals", items);
        }
    }
}