using System.Collections.Generic;
using MyOnlineShop.Models.ShopingCartModels;

namespace MyOnlineShop.Web.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}