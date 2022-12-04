using AutoMapper;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
