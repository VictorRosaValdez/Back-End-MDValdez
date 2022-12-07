namespace MDValdez.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public double TotalPrice { get; set; }

    }
}
