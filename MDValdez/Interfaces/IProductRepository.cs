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
        /// Abstract method to get a product by Id.
        /// </summary>
        /// <returns>A productDto</returns>
        Task<ActionResult<IEnumerable<Product>>> GetProductByIdAsync();

    }
}
