using AutoMapper;
using MDValdez.DTOs.AccountDTOs;
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
        private readonly IOrderRepository _order;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all products.
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
    }
}
