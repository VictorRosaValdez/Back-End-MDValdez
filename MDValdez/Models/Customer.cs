using Microsoft.EntityFrameworkCore;

namespace MDValdez.Models
{
    public class Customer : Account
    {
        public string CustomerName { get; set; }
        public string adress { get; set; }

        // Navigation Property
        public ICollection<Order> Order { get; set; }
        public ICollection<ShoppingCart> ShoppingCart { get; set; }


    }
}
