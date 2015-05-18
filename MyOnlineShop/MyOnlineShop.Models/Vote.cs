using System.ComponentModel.DataAnnotations;

namespace MyOnlineShop.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public string VotedById { get; set; }
        public virtual ApplicationUser VotedBy { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
