using MDValdez.Models;

namespace MDValdez.DTOs.AccountDTOs
{
    public class ShoppingCartCreateDTO
    {

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public double TotalPrice { get; set; }

    }
}
