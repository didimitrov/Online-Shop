using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyOnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Title is required")]
        //[StringLength(160)]
        public string Title { get; set; }

        public virtual Category Category { get; set; }

        //[DisplayName("Category")]
        public int CategoryId { get; set; }

        //[Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        //[DisplayName("Album Art URL")]
        public string ProductArtUrl { get; set; }
        
       
    }
}
