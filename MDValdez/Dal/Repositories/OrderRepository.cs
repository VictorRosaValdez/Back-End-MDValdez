using MDValdez.DTOs.AccountDTOs;
using MDValdez.DTOs.ProductDTOs;
using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDValdez.Dal.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // Variable for the DbContext
        private readonly MDDbContext _context;

        public OrderRepository(MDDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync()
        {
            var domainOrders = await _context.Order.ToListAsync();

            return domainOrders;
        }

        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id)
        {
            var domainOrder = await _context.Order.FindAsync(id);

            return domainOrder;
        }
        public async Task<ActionResult<Order>> PutOrderAsync(int id, OrderUpdateDTO orderDto)
        {
            var domainOrder = _context.Order.Find(id);

            if (domainOrder == null)
            {
                return null;
            }
            else
            {
                domainOrder.OrderDate = orderDto.OrderDate;
                domainOrder.CustomerId = orderDto.CustomerId;
                domainOrder.OrderAmount = orderDto.OrderAmount;
              
                await _context.SaveChangesAsync();
            }
            return domainOrder;
        }

        public async Task<ActionResult<Order>> PostOrderAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<ActionResult<Order>> DeleteOrderAsync(int id)
        {
            var domainOrder = await _context.Order.FindAsync(id);

            if (domainOrder == null)
            {
                return null;
            }

            else
            {
                _context.Order.Remove(domainOrder);
                await _context.SaveChangesAsync();
            }

            return domainOrder;
        }
    }
}
