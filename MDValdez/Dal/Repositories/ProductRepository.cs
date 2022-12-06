using MDValdez.DTOs.ProductDTOs;
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

        public async Task<ActionResult<Product>> PutProductAsync(int id, ProductUpdateDTO productDto)
        {
            var domainProduct = _context.Product.Find(id);

            if (domainProduct == null)
            {
                return null;
            }
            else
            {
                domainProduct.Name = productDto.Name;
                domainProduct.Description = productDto.Description;
                domainProduct.picture = productDto.picture;
                domainProduct.OrderCode = productDto.OrderCode;
                domainProduct.Stock = productDto.Stock;
                await _context.SaveChangesAsync();
            }
            return domainProduct;
        }

        public async Task<ActionResult<Product>> PostProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<ActionResult<Product>> DeleteProductAsync(int id)
        {
            var domainProduct = await _context.Product.FindAsync(id);

            if (domainProduct == null)
            {
                return null;
            }

            else
            {
                _context.Product.Remove(domainProduct);
                await _context.SaveChangesAsync();
            }

            return domainProduct;
        }
    }
}
