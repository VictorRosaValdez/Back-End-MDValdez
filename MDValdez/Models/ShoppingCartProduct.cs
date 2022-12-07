using Microsoft.EntityFrameworkCore.Query;

namespace MDValdez.Models
{
    public class ShoppingCartProduct
    {
        public int ProductId { get; set; }

        // Navigation property product

        public Product Product { get; set; }

        public int ShoppingCartId { get; set; }

        // Navigation property shoppingcart

        public ShoppingCart ShoppingCart { get; set; }
    }
}
