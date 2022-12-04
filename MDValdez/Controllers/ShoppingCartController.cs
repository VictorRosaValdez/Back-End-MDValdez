using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
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

        /// <summary>
        /// Get a shoppingcart by Id
        /// </summary>
        /// <param name="id">The shoppingcart Id</param>
        /// <returns>Return a shoppingcart object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartReadDTO>> GetProductById(int id)
        {
            var domainShoppingCart = await _shoppingCart.GetShoppingCartByIdAsync(id);

            var dtoShoppingCart = _mapper.Map<ShoppingCartReadDTO>(domainShoppingCart.Value);

            if (dtoShoppingCart == null)
            {
                return NotFound();
            }

            return dtoShoppingCart;
        }
    }
}
