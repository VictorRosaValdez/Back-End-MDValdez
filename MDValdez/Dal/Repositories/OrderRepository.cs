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

        public Task<ActionResult<IEnumerable<Order>>> GetOrderByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
