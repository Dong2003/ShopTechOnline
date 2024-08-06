using ShopTechOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopTechOnline.Models.EF;

namespace ShopTechOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(int ? page)
        {
            IEnumerable<Order> items = db.orders.OrderByDescending(x => x.CreatedDate).ToList();
            var pageSize = 10;
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

        // Xem chi tiết đơn đặt hàng
        public ActionResult ViewCart(int id)
        {
            var items = db.orders.Find(id);
            return View(items);
        }

        // Hiển thị danh sách sản phẩm
        public ActionResult Partial_Product(int id)
        {
            var items = db.orderDetails.Where(x => x.OrderID == id).ToList();
            return PartialView(items);
        }

        // Xử lý thanh trạng thái thanh toán
        [HttpPost]
        public ActionResult UpdateTT(int id, int trangthai)
        {
            var items = db.orders.Find(id);
            if(items != null)
            {
                db.orders.Attach(items);
                items.TypePayment = trangthai;
                db.Entry(items).Property( x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { msg = "Success", Success = true });
            }
            return Json(new { msg = "UnSuccess", Success = false });
        }
    }
}