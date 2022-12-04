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
    }
}
