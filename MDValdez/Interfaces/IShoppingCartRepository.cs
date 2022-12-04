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

    }
}
