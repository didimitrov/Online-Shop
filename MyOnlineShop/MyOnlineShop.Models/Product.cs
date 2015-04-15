namespace MyOnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public virtual Category Category { get; set; }
        
        public int CategoryId { get; set; }

        public decimal Price { get; set; }
        
        public string ProductArtUrl { get; set; }
        
       
    }
}
