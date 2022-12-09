using Microsoft.EntityFrameworkCore;

namespace MDValdez.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public string OrderCode { get; set; }

        public string? picture { get; set; }
        public int Stock { get; set; }
        
    }
}
