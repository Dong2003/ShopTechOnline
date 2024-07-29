using ShopTechOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partial_ItemsByCateID()
        {
            var items = db.products.Where( x => x.IsHome).Take(12).ToList();
            return PartialView(items);
        }
    }
}