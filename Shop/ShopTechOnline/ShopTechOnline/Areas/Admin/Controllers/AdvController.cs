using ShopTechOnline.Models;
using ShopTechOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Areas.Admin.Controllers
{
    public class AdvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Adv
        public ActionResult Index(string searchtext, int ? page)
        {
            var pageSize = 8;
            if(page == null)
            {
                page = 1;
            }
            IEnumerable<Adv> item = db.advs.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(searchtext))
            {
                item = item.Where(x => x.Title.Contains(searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page):1;
            return View(item);
        }


    }
}