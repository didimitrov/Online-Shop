using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyOnlineShop.Data.Migrations;
using MyOnlineShop.Models;
using MyOnlineShop.Models.ShopingCartModels;


namespace MyOnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Cart> Carts { get; set; }
        public IDbSet<Order> Orders{ get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
