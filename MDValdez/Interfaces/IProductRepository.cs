using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDValdez.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Absctract method to get all products.
        /// </summary>
        /// <returns>A list of prouductsDto</returns>
        Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync();

        /// <summary>
        /// Get a product by Id.
        /// </summary>
        /// <param name="id">Th product ID</param>
        /// <returns>A product object</returns>
        Task<ActionResult<Product>> GetProductByIdAsync(int id);

    }
}
