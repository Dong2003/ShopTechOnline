using ShopTechOnline.Models;
using ShopTechOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ShopTechOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Category
        public ActionResult Index(int ? page)
        {

            var pageSize = 8;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = db.categories.OrderByDescending(x => x.ID).ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model) 
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiledDate = DateTime.Now;
                model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit( int id)
        {
            var items = db.categories.Find(id);
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.categories.Attach(model);
                model.ModifiledDate = DateTime.Now;
                model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.Entry(model).Property(c => c.Title).IsModified = true;
                db.Entry(model).Property(c => c.Description).IsModified = true;
                db.Entry(model).Property(c => c.Alias).IsModified = true;
                db.Entry(model).Property(c => c.SeoDescription).IsModified = true;
                db.Entry(model).Property(c => c.SeoKeywords).IsModified = true;
                db.Entry(model).Property(c => c.SeoTitle).IsModified = true;
                db.Entry(model).Property(c => c.Position).IsModified = true;
                db.Entry(model).Property(c => c.ModifiledDate).IsModified = true;
                db.Entry(model).Property(c => c.ModifierBy).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.categories.Find(id);
            if(item != null)
            {
                //var DeleteItem = db.categories.Attach(item);
                db.categories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
;            }
            return Json(new { success = false});
        }
    }
}