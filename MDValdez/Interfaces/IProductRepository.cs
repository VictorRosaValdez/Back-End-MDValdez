using MDValdez.DTOs.ProductDTOs;
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
        /// Absctract method to get a product by Id.
        /// </summary>
        /// <param name="id">Th product ID</param>
        /// <returns>A product object</returns>
        Task<ActionResult<Product>> GetProductByIdAsync(int id);

        /// <summary>
        /// Absctract method to update a product.
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <param name="productDto">ProductDto object</param>
        /// <returns></returns>
        Task<ActionResult<Product>> PutProductAsync(int id, ProductUpdateDTO productDto);

        /// <summary>
        /// Absctract method to add a new product.
        /// </summary>
        /// <param name="product">Product type</param>
        /// <returns>The product object</returns>
        Task<ActionResult<Product>> PostProductAsync(Product product);

        /// <summary>
        /// Absctract method to delete a product.
        /// </summary>
        /// <param name="id">Id of the prdoduct</param>
        /// <returns></returns>
        Task<ActionResult<Product>> DeleteProductAsync(int id);

    }
}
