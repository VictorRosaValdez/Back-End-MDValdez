using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
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

        /// <summary>
        /// Absctract method to update an order.
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <param name="orderDto">OrderDto object</param>
        /// <returns></returns>
        Task<ActionResult<Order>> PutOrderAsync(int id, OrderUpdateDTO orderDto);

        /// <summary>
        /// Absctract method to add a new order.
        /// </summary>
        /// <param name="order">Order type</param>
        /// <returns>The product object</returns>
        Task<ActionResult<Order>> PostOrderAsync(Order order);

        /// <summary>
        /// Absctract method to delete an order.
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <returns></returns>
        Task<ActionResult<Order>> DeleteOrderAsync(int id);

    }
}
