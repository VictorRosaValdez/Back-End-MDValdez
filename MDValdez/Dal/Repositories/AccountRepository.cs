using MDValdez.DTOs.AccountDTOs;
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

        public async Task<ActionResult<Customer>> PutAccountAsync(int id, AccountUpdateDTO accountDto)
        {
            var domainAccount = _context.Customer.Find(id);

            if (domainAccount == null)
            {
                return null;
            }
            else
            {
                domainAccount.CustomerName = accountDto.CustomerName;
                domainAccount.adress = accountDto.adress;
                domainAccount.Password = accountDto.Password;

                await _context.SaveChangesAsync();
            }
            return domainAccount;
        }

        public async Task<ActionResult<Customer>> PostAccountAsync(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<ActionResult<Account>> DeleteAccountAsync(int id)
        {
            var domainAccount = await _context.Account.FindAsync(id);

            if (domainAccount == null)
            {
                return null;
            }

            else
            {
                _context.Account.Remove(domainAccount);
                await _context.SaveChangesAsync();
            }

            return domainAccount;
        }
    }
}
