using MDValdez.Models;

namespace MDValdez.DTOs.AccountDTOs
{
    public class ShoppingCartReadDTO
    {
        //public int ShoppingCartId { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public double TotalPrice { get; set; }

        // Navigation Property
        public ICollection<Product> Product { get; set; }


    }
}
