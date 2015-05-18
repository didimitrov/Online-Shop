using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyOnlineShop.Models
{
    public class Product
    {
       // private ICollection<Vote> _votes;
        public Product()
        {
            this.Votes=new HashSet<Vote>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        public virtual Category Category { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        public string ProductArtUrl { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        //public virtual ICollection<Vote> Votes
        //{
        //    get { return this._votes; }
        //    set { this._votes = value; }
        //}
    }
}
