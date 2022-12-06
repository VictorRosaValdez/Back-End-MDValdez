using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace MDValdez.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _order;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <response code="200">Succesfully returns a list of orders</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDTO>>> GetAllOrders()
        {
            var domainOrders = await _order.GetAllOrdersAsync();

            var dtoOrder = _mapper.Map<List<OrderReadDTO>>(domainOrders.Value);

            return dtoOrder;
        }

        /// <summary>
        /// Get an order by Id
        /// </summary>
        /// <param name="id">The order Id</param>
        /// <returns>Return a order object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDTO>> GetOrderById(int id)
        {
            var domainOrder = await _order.GetOrderByIdAsync(id);

            var dtoOrder = _mapper.Map<OrderReadDTO>(domainOrder.Value);

            if (dtoOrder == null)
            {
                return NotFound();
            }

            return dtoOrder;
        }

        /// <summary>
        /// Update an order.
        /// </summary>
        /// <param name="id">The order Id</param>
        /// <param name="orderDto">OrderDto object</param>
        /// <returns>Action result without content</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrder(int id, OrderUpdateDTO orderDto)
        {

            if (id != orderDto.OrderId)
            {
                return BadRequest();
            }


            var domainOrder = await _order.PutOrderAsync(id, orderDto);


            if (domainOrder == null)
            {
                return NotFound();
            }

            try
            {
                await _order.PutOrderAsync(id, orderDto);

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new order object.
        /// </summary>
        /// <param name="orderDto">A order DTO object</param>
        /// <returns>An order Read DTO object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderCreateDTO orderDto)
        {

            var domainOrder = _mapper.Map<Order>(orderDto);


            await _order.PostOrderAsync(domainOrder);

            return domainOrder;
        }

        /// <summary>
        /// Delete an order by Id.
        /// </summary>
        /// <param name="id">Id of the order object</param>
        /// <returns></returns>
        /// <response code="204">Succesfully deleted the order.</response>
        /// <response code="404">Error: The order you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> DeleteOrderAsync(int id)
        {
            var domainOrder = await _order.DeleteOrderAsync(id);

            if (domainOrder == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
