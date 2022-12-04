using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MDValdez.Controllers
{
    [ApiController]
    [Route("api/shoppingcarts")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCart;
        private readonly IMapper _mapper;
        public ShoppingCartController(IShoppingCartRepository shoppingCart, IMapper mapper)
        {
            _shoppingCart = shoppingCart;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <response code="200">Succesfully returns a list of ShoppingCarts</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartReadDTO>>> GetAllShoppingCarts()
        {
            var domainShoppingCarts = await _shoppingCart.GetAllShoppingCartsAsync();

            var dtoShoppingCart = _mapper.Map<List<ShoppingCartReadDTO>>(domainShoppingCarts.Value);

            return dtoShoppingCart;
        }
    }
}
