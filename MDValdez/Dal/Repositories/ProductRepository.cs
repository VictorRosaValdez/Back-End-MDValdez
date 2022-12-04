using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDValdez.Dal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Variable for the DbContext
        private readonly MDDbContext _context;

        /// <summary>
        /// Constructor for the ProductRepository
        /// </summary>
        /// <param name="context"></param>
       public ProductRepository(MDDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            
            var domainProducts = await _context.Product.ToListAsync();

            return domainProducts;
        }

        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var domainProduct = await _context.Product.FindAsync(id);

            return domainProduct;
        }
    }
}
