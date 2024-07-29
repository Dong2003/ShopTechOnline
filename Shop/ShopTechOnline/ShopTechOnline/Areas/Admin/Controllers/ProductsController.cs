using PagedList;
using ShopTechOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTechOnline.Models.EF;

namespace ShopTechOnline.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Products
        public ActionResult Index(int ? page)
        {
            IEnumerable<Product> items = db.products.OrderByDescending(x => x.ID);
            var pageSize = 8;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.productCategories.ToList(), "ID", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add( Product model , List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if( Images != null && Images.Count > 0)
                {
                    for(int i = 0; i < Images.Count; i++)
                    {
                        if( i +1 == rDefault[0])
                        {
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductID = model.ID,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductID = model.ID,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.CreatedDate = DateTime.Now;
                model.ModifiledDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                    if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(db.productCategories.ToList(), "ID", "Title");
            return View(model);
        }

        public ActionResult Edit( int id)
        {
            ViewBag.ProductCategory = new SelectList(db.productCategories.ToList(), "ID", "Title");
            var item = db.products.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiledDate = DateTime.Now;
                model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.products.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.products.Find(id);
            if (item != null)
            {
                var checkImg = item.ProductImages.Where( x => x.ProductID == item.ID );

                if(checkImg != null)
                {
                    foreach (var img in checkImg)
                    {
                        db.ProductImages.Remove(img);
                        db.SaveChanges();
                    }
                }
                db.products.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json( new { success = false});
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }
    }
}