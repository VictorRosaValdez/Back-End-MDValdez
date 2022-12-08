using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /// Get all shoopingcarts.
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
        /// Get a shoppingcart by Id.
        /// </summary>
        /// <param name="id">The shoppingcart Id</param>
        /// <returns>Return a shoppingcart object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartReadDTO>> GetShoppingCartById(int id)
        {
            var domainShoppingCart = await _shoppingCart.GetShoppingCartByIdAsync(id);

            var dtoShoppingCart = _mapper.Map<ShoppingCartReadDTO>(domainShoppingCart.Value);

            if (dtoShoppingCart == null)
            {
                return NotFound();
            }

            return dtoShoppingCart;
        }

        /// <summary>
        /// Update a shoopingcart.
        /// </summary>
        /// <param name="id">The shoppingcart Id</param>
        /// <param name="shoppingCartDto">ShoppingCartDto object</param>
        /// <returns>Action result without content</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutShoppingCart(int id, ShoppingCartUpdateDTO shoppingCartDto)
        {

            if (id != shoppingCartDto.ShoppingCartId)
            {
                return BadRequest();
            }


            var domainShoppingCart = await _shoppingCart.PutShoppingCartAsync(id, shoppingCartDto);


            if (domainShoppingCart == null)
            {
                return NotFound();
            }

            try
            {
                await _shoppingCart.PutShoppingCartAsync(id, shoppingCartDto);

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new shoppingcart object.
        /// </summary>
        /// <param name="shoppingCartDto">A ShoppingCart DTO object</param>
        /// <returns>A shoppingcart Read DTO object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> PostShoppingCart(ShoppingCartCreateDTO shoppingCartDto)
        {

            var domainShoppingCart = _mapper.Map<ShoppingCart>(shoppingCartDto);

            await _shoppingCart.PostShoppingCartAsync(domainShoppingCart);

            return domainShoppingCart;
        }

        /// <summary>
        /// Delete a shoppingCart by Id.
        /// </summary>
        /// <param name="id">Id of the shoppingCart object</param>
        /// <returns></returns>
        /// <response code="204">Succesfully deleted the shoppingcart.</response>
        /// <response code="404">Error: The shoppingcart you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> DeleteShoppingCartAsync(int id)
        {
            var domainShoppingCart = await _shoppingCart.DeleteShoppingCartAsync(id);

            if (domainShoppingCart == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Get all products in a shoppingCart.
        /// </summary>
        /// <param name="id">ShoppingCart Id</param>
        /// <returns>A list of product objects.</returns>
        /// <response code="200">Succesfully returns the products objects.</response>
        /// <response code="400">Error: Response with this is a bad request.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}/shoppingcart/product")]
        public async Task<ActionResult<ShoppingCart>> GetAllProductsInShoppingCart(int id)
        {
            var productsInShoppingCart = await _shoppingCart.GetAllProductsInhoppingCartAsync(id);

            if (productsInShoppingCart.Value == null)
            {
                return NotFound();
            }


            return Ok(productsInShoppingCart);
        }
    }
}
