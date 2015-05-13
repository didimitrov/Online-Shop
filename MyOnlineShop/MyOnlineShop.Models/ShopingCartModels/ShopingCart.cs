using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOnlineShop.Data;

namespace MyOnlineShop.Models.ShopingCartModels
{
    public class ShopingCart
    {
        ApplicationDbContext db = new ApplicationDbContext();
        string ShopingCartId { get; set; }
        public const string CartSessionKey = "CartID";

        public static ShopingCart GetCart(HttpContextBase context)
        {
            var cart = new ShopingCart();
            cart.ShopingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShopingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            var item = db.Carts.SingleOrDefault(x => x.CartId == CartSessionKey && x.ProductId == product.Id);
            if (item ==null)
            {
                item = new Cart
                {
                    CartId = ShopingCartId,
                    Count = 1,
                    CreatedOn = DateTime.Now,
                    ProductId = product.Id,
                };
                db.Carts.Add(item);
            }
            else
            {
                item.Count++;
            }
            db.SaveChanges();
        }


        private string GetCartId(HttpContextBase context)
        {
            
        }
    }
}
