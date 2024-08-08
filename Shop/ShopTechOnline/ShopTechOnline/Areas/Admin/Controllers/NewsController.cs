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
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/News
        public ActionResult Index(string searchtext, int? page)
        {
            var pageSize = 8;
            if(page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = db.news.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(searchtext))
            {
                items = items.Where( x => x.Alias.Equals(searchtext) || x.Title.Contains(searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex,pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.CategoryID = 6;
                model.ModifiledDate = DateTime.Now;
                model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.news.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit( int id)
        {
            var item = db.news.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiledDate = DateTime.Now;
                model.Alias = ShopTechOnline.Models.Common.FIlter.FilterChar(model.Title);
                db.news.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.news.Find(id);
            if(item != null)
            {
                db.news.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success =  false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.news.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if(items != null && items.Any())
                {
                    foreach(var item in items)
                    {
                        var obj = db.news.Find(Convert.ToInt32(item));
                        db.news.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { succes = false});
        }
    }
}