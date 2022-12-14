using System.ComponentModel.DataAnnotations;

namespace MDValdez.DTOs.ProductDTOs
{
    public class ProductDeleteDTO
    {
        public int ProductId { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }

        public string OrderCode { get; set; }
        public int Stock { get; set; }
    }
}
