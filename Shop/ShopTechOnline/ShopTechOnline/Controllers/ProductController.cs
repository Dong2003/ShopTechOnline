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
        public ActionResult Index(int ? id)
        {
            var items = db.products.ToList();
            //if (id != null) 
            //{
            //    items = items.Where( x => x.ProductCategoryID == id ).ToList();
            //}
            return View(items);
        }

        public ActionResult Detail(string alias,int id)
        {
            var items = db.products.Find(id);
            return View(items); 
        }

        public ActionResult ProductCategory(string alias, int? id)
        {
            var items = db.products.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
            }
            var cate = db.productCategories.Find(id);
            if(cate != null){
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateID = id;
            return View(items);
        }

        public ActionResult Partial_ItemsByCateID()
        {
            var items = db.products.Where( x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }

        public ActionResult Partial_ProductSale()
        {
            var items = db.products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}