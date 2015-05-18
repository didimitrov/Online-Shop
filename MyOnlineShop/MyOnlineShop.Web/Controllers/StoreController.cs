using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyOnlineShop.Data;
using MyOnlineShop.Models;
using MyOnlineShop.Web.ViewModels;

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
            var userId = User.Identity.GetUserId();
            var product = _db.Products.Find(id);

            var productViewModel = new ProductDetailsViewModel
            {
                Category = product.Category,
                CategoryId = product.CategoryId,
                Id = product.Id,
                Price = product.Price,
                ProductArtUrl = product.ProductArtUrl,
                Title = product.Title,
                //todo change db with repo
                UserCanVote = _db.Votes.Any(pesho => pesho.VotedById == userId),
                Votes = product.Votes.Count()
            };

            return View(productViewModel);
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
            var canVote = !_db.Votes.Any(x => x.ProductId == id && x.VotedById == userId);

            if (canVote)
            {
                _db.Products.Find(id).Votes.Add(new Vote()
                {
                    ProductId = id,
                    VotedById = userId
                });
                _db.SaveChanges();
            }

            var votes = _db.Products.Find(id).Votes.Count();

            if (votes != 0)
            {
                return Content(votes.ToString(CultureInfo.InvariantCulture));
            }
            return Content("0");

        }
    }
}