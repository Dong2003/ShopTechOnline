using ShopTechOnline.Models;
using ShopTechOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int id )
        {
            ViewBag.ProductID = id;
            var items = db.ProductImages.Where( x => x.ProductID == id ).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productID, string url) 
        {
            db.ProductImages.Add(new ProductImage
            {
                ProductID = productID,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true});
        }

        [HttpPost]
        public ActionResult Delete(int id) 
        {
            var item = db.ProductImages.Find(id);
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true});
        }
    }
}