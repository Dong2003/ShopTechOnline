using ShopTechOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }

        public ActionResult Partial_Item_ThanhToan()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.items);
            }
            return PartialView();
        }

        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return PartialView(cart.items);
            }
            return PartialView();
        }

        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                return Json(new { Count = cart.items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddToCart(int id , int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0};
            var db = new ApplicationDbContext();
            var checkProduct = db.products.FirstOrDefault( x => x.ID == id );
            if ( checkProduct != null )
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if ( cart == null )
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductID = checkProduct.ID,
                    ProductName = checkProduct.Title,
                    CategoryName = checkProduct.ProductCategory.Title,
                    Alias = checkProduct.Alias,
                    Quantity = quantity
                };
                if (checkProduct.ProductImages.FirstOrDefault(x => x.IsDefault) != null)
                {
                    item.ProductImg = checkProduct.ProductImages.FirstOrDefault(x => x.IsDefault).Image;
                }
                item.Price = checkProduct.Price;
                if (checkProduct.PrcieSale > 0)
                {
                    item.Price = (decimal)checkProduct.PrcieSale;
                }
                item.TotalPrice = item.Quantity * item.Price;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công", code = 1, Count = cart.items.Count };
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json( new { Success = false});
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = true, msg = "", code = -1, Count = 0 };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.items.FirstOrDefault(x => x.ProductID == id);
                if (checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.items.Count };
                }
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                cart.ClearCart();
                return Json(new { Success = true});
            }
            return Json(new { Success = false});
        }
    }
}