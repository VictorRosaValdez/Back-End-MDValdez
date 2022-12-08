using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDValdez.Dal.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        // Variable for the DbContext
        private readonly MDDbContext _context;

        public ShoppingCartRepository(MDDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetAllShoppingCartsAsync()
        {
           
            var domainShoppingCarts = await _context.ShoppingCart.ToListAsync();

            return domainShoppingCarts;
        }

        public async Task<ActionResult<ShoppingCart>> GetShoppingCartByIdAsync(int id)
        {
            var domainShoppingCart = await _context.ShoppingCart.FindAsync(id);

            return domainShoppingCart;
        }

        public async Task<ActionResult<ShoppingCart>> PutShoppingCartAsync(int id, ShoppingCartUpdateDTO shoppingCartDto)
        {
            var domainShoppingCart = _context.ShoppingCart.Find(id);

            if (domainShoppingCart == null)
            {
                return null;
            }
            else
            {
                domainShoppingCart.Date = shoppingCartDto.Date;
                domainShoppingCart.CustomerId = shoppingCartDto.CustomerId;
                domainShoppingCart.TotalPrice = shoppingCartDto.TotalPrice;
        
                await _context.SaveChangesAsync();
            }
            return domainShoppingCart;
        }

        public async Task<ActionResult<ShoppingCart>> PostShoppingCartAsync(ShoppingCart shoppingCart)
        {
            _context.ShoppingCart.Add(shoppingCart);
            await _context.SaveChangesAsync();

            return shoppingCart;
        }

        public async Task<ActionResult<ShoppingCart>> DeleteShoppingCartAsync(int id)
        {
            var domainShoppingCart = await _context.ShoppingCart.FindAsync(id);

            if (domainShoppingCart == null)
            {
                return null;
            }

            else
            {
                _context.ShoppingCart.Remove(domainShoppingCart);
                await _context.SaveChangesAsync();
            }

            return domainShoppingCart;
        }

        /// <summary>
        /// Get all products in a shoppingcart.
        /// </summary>
        /// <param name="id">Id of the shoppingCart.</param>
        /// <returns>A list of products.</returns>
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsInhoppingCartAsync(int id)
        {
            // Using the domain object and not the Dto.
            var productsInShoppingCart = await _context.ShoppingCartProduct
                .Where(s => s.ShoppingCartId == id)
                .Select(m => m.Product)
                .ToListAsync();

            return productsInShoppingCart;
        }
    }
}
