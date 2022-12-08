using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDValdez.Interfaces
{
    public interface IShoppingCartRepository
    {
        /// <summary>
        /// Absctract method to get all ShoppingCarts.
        /// </summary>
        /// <returns>A list of shoppingCartsDto</returns>
        Task<ActionResult<IEnumerable<ShoppingCart>>> GetAllShoppingCartsAsync();

        /// <summary>
        /// Abstract method to get a shoppingCart by Id.
        /// </summary>
        /// <returns>A shoppingCartDto</returns>
        Task<ActionResult<ShoppingCart>> GetShoppingCartByIdAsync(int id);

        /// <summary>
        /// Absctract method to update a shoppingcart.
        /// </summary>
        /// <param name="id">Id of the shoppingcart</param>
        /// <param name="shoppingCartDto">ShoppingCartDto object</param>
        /// <returns></returns>
        Task<ActionResult<ShoppingCart>> PutShoppingCartAsync(int id, ShoppingCartUpdateDTO shoppingCartDto);

        /// <summary>
        /// Absctract method to add a new shoppingcart.
        /// </summary>
        /// <param name="shoppingCart">Product type</param>
        /// <returns>The product object</returns>
        Task<ActionResult<ShoppingCart>> PostShoppingCartAsync(ShoppingCart shoppingCart);

        /// <summary>
        /// Absctract method to delete a product.
        /// </summary>
        /// <param name="id">Id of the prdoduct</param>
        /// <returns></returns>
        Task<ActionResult<ShoppingCart>> DeleteShoppingCartAsync(int id);

        /// <summary>
        /// Absctract method to get all products in a shoppingcarrt.
        /// </summary>
        /// <param name="id">Id of the shoppingcart</param>
        /// <returns></returns>
        Task<ActionResult<IEnumerable<Product>>> GetAllProductsInhoppingCartAsync(int id);


    }
}
