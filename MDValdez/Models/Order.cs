using Microsoft.EntityFrameworkCore;

namespace MDValdez.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public double OrderAmount { get; set; }
    }
}
