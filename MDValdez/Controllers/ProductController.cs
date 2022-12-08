using AutoMapper;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace MDValdez.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <response code="200">Succesfully returns a list of products</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
             

            var dtoProduct = await _product.GetAllProductsAsync();

            return dtoProduct;
        }

       
      /// <summary>
      /// Get a product by Id
      /// </summary>
      /// <param name="id">The product Id</param>
      /// <returns>Return a product object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetProductById(int id)
        {
            var domainProduct = await _product.GetProductByIdAsync(id);

            var dtoProduct = _mapper.Map<ProductReadDTO>(domainProduct.Value);

            if (dtoProduct == null)
            {
                return NotFound();
            }

            return dtoProduct;
        }

        /// <summary>
        /// Update a product.
        /// </summary>
        /// <param name="id">The product Id</param>
        /// <param name="productDto">PrdouctDto object</param>
        /// <returns>Action result without content</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, ProductUpdateDTO productDto)
        {
            
            if (id != productDto.ProductId)
            {
                return BadRequest();
            }

            
            var domainProduct = await _product.PutProductAsync(id, productDto);

            
            if (domainProduct == null)
            {
                return NotFound();
            }

            try
            {
                await _product.PutProductAsync(id, productDto);

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

       /// <summary>
       /// Create a new product object.
       /// </summary>
       /// <param name="productDto">A Product DTO object</param>
       /// <returns>A product Read DTO object.</returns>
       /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductCreateDTO productDto)
        {
            
            var domainProduct = _mapper.Map<Product>(productDto);

            await _product.PostProductAsync(domainProduct);

            return domainProduct;
        }

        /// <summary>
        /// Delete a product by Id.
        /// </summary>
        /// <param name="id">Id of the product object</param>
        /// <returns></returns>
        /// <response code="204">Succesfully deleted the product.</response>
        /// <response code="404">Error: The product you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var domainProduct = await _product.DeleteProductAsync(id);

            if (domainProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
