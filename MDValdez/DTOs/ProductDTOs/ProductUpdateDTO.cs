using System.ComponentModel.DataAnnotations;

namespace MDValdez.DTOs.ProductDTOs
{
    public class ProductUpdateDTO
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
