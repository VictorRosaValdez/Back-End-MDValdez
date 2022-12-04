using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDValdez.Dal.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        // Variable for the DbContext
        private readonly MDDbContext _context;
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomersAsync()
        {
            
            var domainCustomers = await _context.Customer.ToListAsync();

            return domainCustomers;
        }

        public Task<ActionResult<IEnumerable<Customer>>> GetCustomerByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
