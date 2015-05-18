using MyOnlineShop.Models;

namespace MyOnlineShop.Web.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ProductArtUrl { get; set; }

        public decimal Price { get; set; }

        public bool UserCanVote { get; set; }

        public int Votes { get; set; }


        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}