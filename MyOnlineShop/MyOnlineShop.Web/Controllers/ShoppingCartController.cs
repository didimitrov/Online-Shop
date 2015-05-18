using System.Linq;
using System.Web.Mvc;
using MyOnlineShop.Data;
using MyOnlineShop.Models.ShopingCartModels;
using MyOnlineShop.Web.ViewModels;

namespace MyOnlineShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var item = ShoppingCart.GetCart(HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = item.GetCartItems(),
                CartTotal = item.Total()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            var cart = ShoppingCart.GetCart(HttpContext);

            cart.AddToCart(product);

            return RedirectToAction("Index");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            var productName = db.Carts
                .Single(item => item.RecordId == id).Product.Title;

            // Remove from cart
            var itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                          " has been removed from your shopping cart.",
                CartTotal = cart.Total(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

    
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}