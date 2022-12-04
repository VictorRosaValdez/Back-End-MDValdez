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
    }
}
