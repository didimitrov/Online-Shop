using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOnlineShop.Data;

namespace MyOnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            var products = db.Products.OrderBy(x => x.Id).ToList();
            var minId = db.Products.Min(x => x.Id);
            ViewBag.ProductMinId = minId;
            return View(products);
        }

      
    }
}