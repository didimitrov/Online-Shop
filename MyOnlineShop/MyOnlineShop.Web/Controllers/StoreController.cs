using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
            var categoryModel = _db.Categories.Include("Products").SingleOrDefault(x => x.Name==category);
            //var categoryModel = new Category {Name = category};
            return View(categoryModel);
        }
        
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var product = _db.Products.Find(id);
            //var product = new Product {Title = "Ql", Id = id};

            return View(product);
        }

        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = _db.Categories.ToList();
            return PartialView(categories);
        }

        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();

           _db.Products.Find(id).Votes.Add(new Vote()
           {
               ProductId = id,
               VotedById = userId
           });
            _db.SaveChanges();

            var votes = _db.Products.Find(id).Votes.Count();
            return Content(votes.ToString(CultureInfo.InvariantCulture));
        }
    }
}