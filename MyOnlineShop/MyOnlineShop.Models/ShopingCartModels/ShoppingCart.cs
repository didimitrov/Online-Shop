using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOnlineShop.Data;


namespace MyOnlineShop.Models.ShopingCartModels
{
    public partial class ShoppingCart
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public string ShopingCartId { get; set; }

        public const string CartSessionKey = "CartID";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShopingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            var item = db.Carts.SingleOrDefault(x => x.CartId == ShopingCartId && x.ProductId == product.Id);
            if (item == null)
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

        public int RemoveFromCart(int id)
        {
            var item = db.Carts.SingleOrDefault(cart => cart.CartId == ShopingCartId && cart.RecordId == id);
            var itemCount = 0;
            if (item != null)
            {
                if (item.Count > 1)
                {
                    item.Count--;
                    itemCount = item.Count;

                }
                else
                {
                    db.Carts.Remove(item);
                }
                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var items = db.Carts.Where(cart => cart.CartId == ShopingCartId);

            foreach (var item in items)
            {
                db.Carts.Remove(item);
            }
            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            var items = db.Carts.Where(cart => cart.CartId == ShopingCartId).ToList();
            return items;
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            var count = (from cartItems in db.Carts
                         where cartItems.CartId == ShopingCartId
                         select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;

        }

        public decimal Total()
        {
            var total = (from cartItems in db.Carts
                         where cartItems.CartId == ShopingCartId
                         select (int?)cartItems.Count *
                         cartItems.Product.Price).Sum();

            //var total =
            //    db.Carts.Where(cart => cart.CartId == ShopingCartId)
            //    .Select(cart => cart.Count * cart.Product.Price).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Product.Price);

                db.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }


        private string GetCartId(HttpContextBase context)
        {
            if (context.Session != null && context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Carts.Where(
                c => c.CartId == ShopingCartId);

            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }
    }
}
