using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyOnlineShop.Models
{
    public class Category
    {
        //public Category()
        //{
        //    Products= new HashSet<Product>();
        //}

        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }


        
    }
}
