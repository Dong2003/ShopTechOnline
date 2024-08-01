﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> items { get; set; }
        public ShoppingCart()
        {
            this.items = new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, int Quantity) 
        {
            var checkExits = items.FirstOrDefault( x => x.ProductID == item.ProductID );
            if (checkExits != null)
            {
                checkExits.Quantity += Quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var checkExits = items.SingleOrDefault( x => x.ProductID == id );
            if (checkExits != null)
            {
                items.Remove(checkExits);
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var checkExits = items.SingleOrDefault(x => x.ProductID == id);
            if (checkExits != null)
            {
                checkExits.Quantity = quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }

        public decimal GetTotalPrice()
        {
            return items.Sum( x => x.TotalPrice );
        }

        public int GetTotalQuantity()
        {
            return items.Sum(x => x.Quantity);
        }

        public void ClearCart()
        {
            items.Clear();
        }
    }

    public class ShoppingCartItem
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Alias { get; set; }

        public string CategoryName { get; set; }

        public string ProductImg { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}