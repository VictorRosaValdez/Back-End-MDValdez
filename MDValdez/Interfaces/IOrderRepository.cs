using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDValdez.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Absctract method to get all orders.
        /// </summary>
        /// <returns>A list of ordersDto</returns>
        Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync();

        /// <summary>
        /// Abstract method to get an order by Id.
        /// </summary>
        /// <returns>A orderDto</returns>
        Task<ActionResult<Order>> GetOrderByIdAsync(int id);

    }
}
