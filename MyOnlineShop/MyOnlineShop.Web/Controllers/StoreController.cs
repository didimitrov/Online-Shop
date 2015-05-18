using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyOnlineShop.Data;
using MyOnlineShop.Data.Repository;
using MyOnlineShop.Models;
using MyOnlineShop.Web.ViewModels;

namespace MyOnlineShop.Web.Controllers
{
    public class StoreController : Controller
    {
        //readonly ApplicationDbContext _db= new ApplicationDbContext();
        private readonly IRepository<Category> _category;
        private readonly IRepository<Vote> _vote;
        private readonly IRepository<Product> _product;

        public StoreController(IRepository<Category> category, IRepository<Vote> vote, IRepository<Product> product)
        {
            _category = category;
            _vote = vote;
            _product = product;
        }


        // GET: Store
        public ActionResult Index()
        {
            var categories = _category.All().ToList();


           
            return View(categories);
        }

        public ActionResult Browse(string category)
        {
            var categoryModel = _category.All().Include("Products").SingleOrDefault(x => x.Name==category);
            //var categoryModel = new Category {Name = category};
            return View(categoryModel);
        }
        
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var product = _product.All().SingleOrDefault(x => x.Id==id);

            if (product != null)
            {
                var productViewModel = new ProductDetailsViewModel
                {
                    Category = product.Category,
                    CategoryId = product.CategoryId,
                    Id = product.Id,
                    Price = product.Price,
                    ProductArtUrl = product.ProductArtUrl,
                    Title = product.Title,
                    //todo change db with repo
                    UserCanVote = _vote.All().Any(pesho => pesho.VotedById == userId),
                    Votes = product.Votes.Count()
                };

                return View(productViewModel);
            }
            return Content("Product is null");
        }

        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = _category.All().ToList();
            return PartialView(categories);
        }

        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();
            var canVote = !_vote.All().Any(x => x.ProductId == id && x.VotedById == userId);

            if (canVote)
            {
                var singleOrDefault = _product.All().SingleOrDefault(x => x.Id==id);
                if (singleOrDefault != null)
                    singleOrDefault.Votes.Add(new Vote
                    {
                        ProductId = id,
                        VotedById = userId
                    });
                _product.SaveChanges();
            }

            var votes = _product.GetById(id).Votes.Count();

            if (votes != 0)
            {
                return Content(votes.ToString(CultureInfo.InvariantCulture));
            }
            return Content("0");

        }
    }
}