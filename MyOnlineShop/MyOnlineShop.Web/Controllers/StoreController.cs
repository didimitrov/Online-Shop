using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyOnlineShop.Data;
using MyOnlineShop.Models;

namespace MyOnlineShop.Web.Controllers
{
    public class StoreController : Controller
    {
        readonly ApplicationDbContext _db= new ApplicationDbContext();

        // GET: Store
        public ActionResult Index()
        {
            var categories = _db.Categories.ToList();


           
            return View(categories);
        }

        public ActionResult Browse(string category)
        {
            var categoryModel = new Category {Name = category};
            return View(categoryModel);
        }
        
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var product = new Product {Title = "Ql", Id = id};

            return View(product);
        }
    }
}