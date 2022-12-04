using MDValdez.Interfaces;
using MDValdez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDValdez.Dal.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        // Variable for the DbContext
        private readonly MDDbContext _context;

        /// <summary>
        /// Constructor for the AccountRepository
        /// </summary>
        /// <param name="context"></param>
        public AccountRepository(MDDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccountsAsync()
        {

            var domainAccounts = await _context.Account.ToListAsync();

            return domainAccounts;
        }

        public async Task<ActionResult<Account>> GetAccountByIdAsync(int id)
        {
            var domainAccount = await _context.Account.FindAsync(id);

            return domainAccount;
        }
    }
}
