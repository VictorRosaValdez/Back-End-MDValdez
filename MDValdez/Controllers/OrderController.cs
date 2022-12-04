using AutoMapper;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MDValdez.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OrderController : ControllerBase
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        public OrderController(IProductRepository product, IMapper mapper)
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
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetAllProducts()
        {
            var domainProducts = await _product.GetAllProductsAsync();

            var dtoProduct = _mapper.Map<List<ProductReadDTO>>(domainProducts.Value);

            return dtoProduct;
        }
    }
}
